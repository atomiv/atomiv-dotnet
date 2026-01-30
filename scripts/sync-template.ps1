# Sync template from template/microservice to pck/content
# This ensures pck/content always reflects the latest template source

param (
    [string]$rootPath = '.'
)

$sourcePath = Join-Path $rootPath "template\microservice"
$targetPath = Join-Path $rootPath "pck\content"

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
    ".log",
    ".user",
    "*.suo",
    "*.user",
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
        
        # Copy directory with exclusions
        robocopy $source $target /E /XD $excludePatterns /XF $excludePatterns /NFL /NDL /NJH /NJS /nc /ns /np
        
        # robocopy returns 0-7 for success, 8+ for errors
        if ($LASTEXITCODE -ge 8) {
            Write-Error "Failed to sync $dir"
            exit 1
        }
    } else {
        Write-Warning "Source directory not found: $source"
    }
}

Write-Host "Template sync completed successfully"
