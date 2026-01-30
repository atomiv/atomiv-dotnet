# Sync template from template/microservice to pck/content
# This ensures pck/content always reflects the latest template source

param (
    [string]$rootPath = '.'
)

$sourcePath = Join-Path $rootPath "template/microservice"
$targetPath = Join-Path $rootPath "pck/content"

Write-Host "Syncing template from $sourcePath to $targetPath"

# Directories to sync
$directoriesToSync = @(
    "src",
    "test"
)

# Files and patterns to exclude
$excludePatterns = @(
    "bin",
    "obj",
    ".vs",
    "*.log",
    "*.user",
    "*.suo",
    "TestResults"
)

foreach ($dir in $directoriesToSync) {
    $source = Join-Path $sourcePath $dir
    $target = Join-Path $targetPath $dir
    
    if (Test-Path $source) {
        Write-Host "Syncing $dir..."
        
        # Remove target directory if exists
        if (Test-Path $target) {
            Remove-Item -Path $target -Recurse -Force
        }
        
        # Cross-platform copy using PowerShell
        # Copy all files and subdirectories, excluding specified patterns
        Copy-Item -Path $source -Destination $target -Recurse -Force -Exclude $excludePatterns
        
        # Remove excluded directories from copied content
        foreach ($pattern in $excludePatterns) {
            $excludedDirs = Get-ChildItem -Path $target -Directory -Recurse -Filter $pattern -ErrorAction SilentlyContinue
            foreach ($excludedDir in $excludedDirs) {
                Remove-Item -Path $excludedDir.FullName -Recurse -Force -ErrorAction SilentlyContinue
            }
        }
        
        Write-Host "Synced $dir successfully"
    } else {
        Write-Error "Source directory not found: $source"
        exit 1
    }
}

Write-Host "Template sync completed successfully"
