# Release Script - Automates version update, commit, and tag creation

param (
    [Parameter(Mandatory=$true)]
    [string]$Version,
    [string]$Message = "",
    [switch]$DryRun
)

# Validate version format
if ($version -notmatch '^\d+\.\d+\.\d+$') {
    Write-Error "Version must be in format X.Y.Z (e.g., 8.0.0)"
    exit 1
}

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  Atomiv Release Process - v$version" -ForegroundColor Cyan
if ($DryRun) {
    Write-Host "  (DRY RUN - No commits or tags will be created)" -ForegroundColor Yellow
}
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Step 1: Update versions
Write-Host "[1/5] Updating project versions to $version..." -ForegroundColor Yellow
$versionScript = Join-Path $PSScriptRoot "Update-ProjectVersions.ps1"
try {
    & $versionScript -version $version -rootPath (Resolve-Path "$PSScriptRoot\..")
    if (-not $?) {
        throw "Version script exited with a non-success status."
    }
} catch {
    $details = $_.Exception.Message
    if ($_.Exception.InnerException) {
        $details = "$details | Inner: $($_.Exception.InnerException.Message)"
    }
    Write-Error "Version update failed: $details"
    exit 1
}

Write-Host "✓ Version updated successfully" -ForegroundColor Green
Write-Host ""

# Step 2: Restore dependencies
Write-Host "[2/8] Restoring dependencies..." -ForegroundColor Yellow
Push-Location (Resolve-Path "$PSScriptRoot\..")
try {
    dotnet restore Atomiv.sln
    if ($LASTEXITCODE -ne 0) {
        throw "Restore failed"
    }
    Write-Host "✓ Dependencies restored" -ForegroundColor Green
} finally {
    Pop-Location
}
Write-Host ""

# Step 3: Build solution
Write-Host "[3/8] Building solution (Release)..." -ForegroundColor Yellow
Push-Location (Resolve-Path "$PSScriptRoot\..")
try {
    dotnet build Atomiv.sln --configuration Release --no-restore
    if ($LASTEXITCODE -ne 0) {
        throw "Build failed"
    }
    Write-Host "✓ Solution built successfully" -ForegroundColor Green
} finally {
    Pop-Location
}
Write-Host ""

# Step 4: Sync template
Write-Host "[4/8] Syncing template from source to package..." -ForegroundColor Yellow
Push-Location (Resolve-Path "$PSScriptRoot\..")
try {
    & "$PSScriptRoot\Sync-TemplateContent.ps1"
    if ($LASTEXITCODE -ne 0) {
        throw "Template sync failed"
    }
    Write-Host "✓ Template synced successfully" -ForegroundColor Green
} finally {
    Pop-Location
}
Write-Host ""

# Step 5: Convert template references
Write-Host "[5/8] Converting template project references to package references..." -ForegroundColor Yellow
Push-Location (Resolve-Path "$PSScriptRoot\..")
try {
    & "$PSScriptRoot\Convert-TemplateReferences.ps1" -version $version
    if ($LASTEXITCODE -ne 0) {
        throw "Template reference conversion failed"
    }
    Write-Host "✓ Template references converted successfully" -ForegroundColor Green
} finally {
    Pop-Location
}
Write-Host ""

# Step 6: Update .nuspec version
Write-Host "[6/8] Updating template package version in .nuspec..." -ForegroundColor Yellow
Push-Location (Resolve-Path "$PSScriptRoot\..")
try {
    $nuspecPath = "pck\Atomiv.Templates.nuspec"
    $nuspecContent = Get-Content $nuspecPath -Raw
    $nuspecContent = $nuspecContent -replace '<version>.*?</version>', "<version>$version</version>"
    Set-Content -Path $nuspecPath -Value $nuspecContent
    Write-Host "✓ .nuspec version updated to $version" -ForegroundColor Green
} finally {
    Pop-Location
}
Write-Host ""

# Step 7: Show changes
Write-Host "[7/8] Changes to be committed:" -ForegroundColor Yellow
git status --short
Write-Host ""

Write-Host "Sample diff (first changed file):" -ForegroundColor Yellow
$firstChanged = git diff --name-only | Select-Object -First 1
if ($firstChanged) {
    git diff $firstChanged | Select-Object -First 20
    Write-Host "... (showing first 20 lines only)" -ForegroundColor Gray
}
Write-Host ""

# Step 8: Confirm
Write-Host "[8/10] Ready to commit and tag?" -ForegroundColor Yellow
Write-Host "This will:" -ForegroundColor White
Write-Host "  - Commit all changes" -ForegroundColor White
Write-Host "  - Create tag v$version" -ForegroundColor White
Write-Host "  - Push to origin/master" -ForegroundColor White
Write-Host "  - Push tag (triggers GitHub Actions publish)" -ForegroundColor White
Write-Host ""

if ($DryRun) {
    Write-Host "DRY RUN MODE: No changes will be committed or tagged." -ForegroundColor Yellow
    Write-Host "Changes preview:" -ForegroundColor Yellow
    git status --short
    Write-Host ""
    Write-Host "✓ Dry run completed successfully. To proceed, run without -DryRun flag." -ForegroundColor Green
    exit 0
}

$confirmation = Read-Host "Continue? (yes/no)"
if ($confirmation -ne "yes") {
    Write-Host "Release cancelled. Changes preserved but not committed." -ForegroundColor Yellow
    Write-Host "Run 'git checkout .' to revert changes if needed." -ForegroundColor Gray
    exit 0
}

# Step 9: Commit
Write-Host ""
Write-Host "[9/10] Committing changes..." -ForegroundColor Yellow

if ([string]::IsNullOrWhiteSpace($message)) {
    $message = "Release v$version"
}

git add .
git commit -m $message

if ($LASTEXITCODE -ne 0) {
    Write-Error "Commit failed"
    exit 1
}

Write-Host "✓ Changes committed" -ForegroundColor Green
Write-Host ""

# Step 10: Tag and push
Write-Host "[10/10] Creating and pushing tag v$version..." -ForegroundColor Yellow

git tag "v$version"

if ($LASTEXITCODE -ne 0) {
    Write-Error "Tag creation failed"
    exit 1
}

Write-Host "Pushing to origin..." -ForegroundColor Yellow
git push origin master
git push origin "v$version"

if ($LASTEXITCODE -ne 0) {
    Write-Error "Push failed"
    exit 1
}

Write-Host ""
Write-Host "========================================" -ForegroundColor Green
Write-Host "  ✓ Release v$version Complete!" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Green
Write-Host ""
Write-Host "GitHub Actions will now:" -ForegroundColor White
Write-Host "  1. Build the solution" -ForegroundColor White
Write-Host "  2. Pack all packages" -ForegroundColor White
Write-Host "  3. Publish to NuGet.org" -ForegroundColor White
Write-Host "  4. Create GitHub Release" -ForegroundColor White
Write-Host ""
Write-Host "Monitor progress at:" -ForegroundColor Yellow
Write-Host "  https://github.com/atomiv/atomiv-dotnet/actions" -ForegroundColor Cyan
Write-Host ""
