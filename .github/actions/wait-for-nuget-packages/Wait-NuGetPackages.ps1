param(
    [Parameter(Mandatory=$true)]
    [string]$Version,
    
    [Parameter(Mandatory=$true)]
    [string]$PackagesCsv,
    
    [Parameter(Mandatory=$false)]
    [int]$MaxWaitSeconds = 1800,
    
    [Parameter(Mandatory=$false)]
    [int]$IntervalSeconds = 30
)

$ErrorActionPreference = 'Stop'
$ELAPSED = 0

Write-Host "Polling NuGet every ${IntervalSeconds}s (max ${MaxWaitSeconds}s) for packages version ${Version}..."

# Parse comma-separated packages list
$PACKAGES = $PackagesCsv -split ',' | ForEach-Object { $_.Trim() }

while ($ELAPSED -lt $MaxWaitSeconds) {
    $ALL_AVAILABLE = $true
    
    foreach ($PACKAGE in $PACKAGES) {
        Write-Host "Checking ${PACKAGE} ${Version}..."
        $PACKAGE_LOWER = $PACKAGE.ToLower()
        $URL = "https://api.nuget.org/v3-flatcontainer/${PACKAGE_LOWER}/index.json"
        
        try {
            $RESPONSE = Invoke-RestMethod -Uri $URL -ErrorAction Stop
            
            if ($RESPONSE.versions -contains $Version) {
                Write-Host "✓ ${PACKAGE} ${Version} is available" -ForegroundColor Green
            } else {
                Write-Host "✗ ${PACKAGE} ${Version} not yet available" -ForegroundColor Yellow
                $ALL_AVAILABLE = $false
                break
            }
        } catch {
            Write-Host "✗ ${PACKAGE} ${Version} not yet available (API error)" -ForegroundColor Yellow
            $ALL_AVAILABLE = $false
            break
        }
    }
    
    if ($ALL_AVAILABLE) {
        Write-Host "All packages are available on NuGet!" -ForegroundColor Green
        exit 0
    }
    
    Write-Host "Waiting ${IntervalSeconds} seconds before next check..."
    Start-Sleep -Seconds $IntervalSeconds
    $ELAPSED += $IntervalSeconds
    Write-Host "Elapsed time: ${ELAPSED}s / ${MaxWaitSeconds}s"
}

Write-Host "ERROR: Timeout reached after ${MaxWaitSeconds}s. Packages not available on NuGet." -ForegroundColor Red
exit 1
