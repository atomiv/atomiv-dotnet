# Release Script - Automates version update, commit, and tag creation

param (
    [Parameter(Mandatory=$true)]
    [string]$version,
    [string]$message = ""
)

# Validate version format
if ($version -notmatch '^\d+\.\d+\.\d+$') {
    Write-Error "Version must be in format X.Y.Z (e.g., 8.0.0)"
    exit 1
}

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  Atomiv Release Process - v$version" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Step 1: Update versions
Write-Host "[1/5] Updating project versions to $version..." -ForegroundColor Yellow
& "$PSScriptRoot\version.ps1" -version $version

if ($LASTEXITCODE -ne 0) {
    Write-Error "Version update failed"
    exit 1
}

Write-Host "✓ Version updated successfully" -ForegroundColor Green
Write-Host ""

# Step 2: Show changes
Write-Host "[2/5] Changes to be committed:" -ForegroundColor Yellow
git status --short
Write-Host ""

Write-Host "Sample diff (first changed file):" -ForegroundColor Yellow
$firstChanged = git diff --name-only | Select-Object -First 1
if ($firstChanged) {
    git diff $firstChanged | Select-Object -First 20
    Write-Host "... (showing first 20 lines only)" -ForegroundColor Gray
}
Write-Host ""

# Step 3: Confirm
Write-Host "[3/5] Ready to commit and tag?" -ForegroundColor Yellow
Write-Host "This will:" -ForegroundColor White
Write-Host "  - Commit all changes" -ForegroundColor White
Write-Host "  - Create tag v$version" -ForegroundColor White
Write-Host "  - Push to origin/master" -ForegroundColor White
Write-Host "  - Push tag (triggers GitHub Actions publish)" -ForegroundColor White
Write-Host ""

$confirmation = Read-Host "Continue? (yes/no)"
if ($confirmation -ne "yes") {
    Write-Host "Release cancelled. Changes preserved but not committed." -ForegroundColor Yellow
    Write-Host "Run 'git checkout .' to revert changes if needed." -ForegroundColor Gray
    exit 0
}

# Step 4: Commit
Write-Host ""
Write-Host "[4/5] Committing changes..." -ForegroundColor Yellow

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

# Step 5: Tag and push
Write-Host "[5/5] Creating and pushing tag v$version..." -ForegroundColor Yellow

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
