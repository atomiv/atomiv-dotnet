#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Runs tests locally with Docker Compose setup for databases.

.DESCRIPTION
    This script:
    1. Starts Docker Compose with SQL Server and MongoDB
    2. Waits for databases to be ready
    3. Restores dependencies
    4. Builds the solution
    5. Runs framework tests (excluding Selenium tests)
    6. Optionally stops Docker Compose

.PARAMETER NoCleanup
    If specified, does not stop Docker Compose at the end.

.PARAMETER SkipDatabaseSetup
    If specified, skips Docker Compose setup and assumes databases are already running.

.EXAMPLE
    .\Run-LocalTests.ps1
    # Runs full test suite with database setup and cleanup

.EXAMPLE
    .\Run-LocalTests.ps1 -NoCleanup
    # Runs tests but leaves Docker containers running

.EXAMPLE
    .\Run-LocalTests.ps1 -SkipDatabaseSetup
    # Assumes databases are already running, skips Docker setup
#>

param(
    [switch]$NoCleanup,
    [switch]$SkipDatabaseSetup
)

$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"

Write-Host "================================" -ForegroundColor Cyan
Write-Host "Local Test Runner" -ForegroundColor Cyan
Write-Host "================================" -ForegroundColor Cyan

$rootDir = Split-Path -Parent $PSScriptRoot
$composeFile = Join-Path $rootDir "template/microservice/docker-compose.yml"

try {
    if (-not $SkipDatabaseSetup) {
        Write-Host "`nStarting Docker Compose..." -ForegroundColor Yellow
        Push-Location $rootDir
        
        try {
            # Start Docker Compose
            docker compose -f $composeFile up -d
            if ($LASTEXITCODE -ne 0) {
                throw "Failed to start Docker Compose"
            }
            
            Write-Host "Waiting for SQL Server to be ready..." -ForegroundColor Yellow
            $sqlReady = $false
            $attempts = 0
            $maxAttempts = 45  # 90 seconds with 2 second intervals
            
            while (-not $sqlReady -and $attempts -lt $maxAttempts) {
                try {
                    $result = docker exec atomiv-sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "YourStrong@Passw0rd" -C -Q "SELECT 1" 2>&1
                    if ($LASTEXITCODE -eq 0) {
                        $sqlReady = $true
                        Write-Host "SQL Server is ready!" -ForegroundColor Green
                    }
                } catch {
                    # Ignore errors, will retry
                }
                
                if (-not $sqlReady) {
                    $attempts++
                    Start-Sleep -Seconds 2
                }
            }
            
            if (-not $sqlReady) {
                Write-Host "Warning: SQL Server may not be ready, but continuing..." -ForegroundColor Yellow
            }
            
            Write-Host "Waiting for MongoDB to be ready..." -ForegroundColor Yellow
            $mongoReady = $false
            $attempts = 0
            $maxAttempts = 30  # 60 seconds with 2 second intervals
            
            while (-not $mongoReady -and $attempts -lt $maxAttempts) {
                try {
                    $result = docker exec atomiv-mongodb mongosh --eval "db.adminCommand({ ping: 1 })" 2>&1
                    if ($LASTEXITCODE -eq 0) {
                        $mongoReady = $true
                        Write-Host "MongoDB is ready!" -ForegroundColor Green
                    }
                } catch {
                    # Ignore errors, will retry
                }
                
                if (-not $mongoReady) {
                    $attempts++
                    Start-Sleep -Seconds 2
                }
            }
            
            if (-not $mongoReady) {
                Write-Host "Warning: MongoDB may not be ready, but continuing..." -ForegroundColor Yellow
            }
        } finally {
            Pop-Location
        }
    }
    
    Write-Host "`nRestoring dependencies..." -ForegroundColor Yellow
    Push-Location $rootDir
    try {
        dotnet restore Atomiv.sln
        if ($LASTEXITCODE -ne 0) {
            throw "Failed to restore dependencies"
        }
        Write-Host "Dependencies restored!" -ForegroundColor Green
    } finally {
        Pop-Location
    }
    
    Write-Host "`nBuilding solution (Release)..." -ForegroundColor Yellow
    Push-Location $rootDir
    try {
        dotnet build Atomiv.sln --configuration Release --no-restore
        if ($LASTEXITCODE -ne 0) {
            throw "Failed to build solution"
        }
        Write-Host "Solution built!" -ForegroundColor Green
    } finally {
        Pop-Location
    }
    
    Write-Host "`nRunning framework tests..." -ForegroundColor Yellow
    Write-Host "(Excluding Selenium tests)" -ForegroundColor Gray
    Push-Location $rootDir
    try {
        $testLogDir = Join-Path $rootDir "TestResults"
        if (-not (Test-Path $testLogDir)) {
            New-Item -ItemType Directory -Path $testLogDir | Out-Null
        }
        
        dotnet test Atomiv.sln `
            --configuration Release `
            --no-build `
            --verbosity normal `
            --logger "trx;LogFileName=framework-test-results.trx" `
            --filter "FullyQualifiedName!~Selenium"
        
        $testExitCode = $LASTEXITCODE
        
        if ($testExitCode -eq 0) {
            Write-Host "`nAll tests passed!" -ForegroundColor Green
        } else {
            Write-Host "`nSome tests failed. Exit code: $testExitCode" -ForegroundColor Yellow
        }
    } finally {
        Pop-Location
    }
    
    Write-Host "`n================================" -ForegroundColor Cyan
    Write-Host "Test run completed" -ForegroundColor Cyan
    Write-Host "================================" -ForegroundColor Cyan
    Write-Host "Test results: $(Join-Path $rootDir "TestResults")" -ForegroundColor Gray
    
} catch {
    Write-Host "`nError: $_" -ForegroundColor Red
    exit 1
} finally {
    if (-not $SkipDatabaseSetup -and -not $NoCleanup) {
        Write-Host "`nCleaning up Docker Compose..." -ForegroundColor Yellow
        Push-Location $rootDir
        try {
            docker compose -f $composeFile down
            Write-Host "Docker Compose stopped!" -ForegroundColor Green
        } catch {
            Write-Host "Warning: Failed to stop Docker Compose: $_" -ForegroundColor Yellow
        } finally {
            Pop-Location
        }
    } elseif (-not $SkipDatabaseSetup -and $NoCleanup) {
        Write-Host "`nDocker Compose is still running. Stop it manually with:" -ForegroundColor Cyan
        Write-Host "docker compose -f $composeFile down" -ForegroundColor Gray
    }
}
