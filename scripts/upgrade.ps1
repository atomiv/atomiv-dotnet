# Parameters

param (
	[string]$rootPath = '.',
	[Parameter(Mandatory=$true)][string]$version = '0.0.0'
)

# Upgrade project version

$projectFiles = Get-ChildItem $rootPath *.csproj -rec
foreach($projectFile in $projectFiles)
{
	Write-Host $projectFile
	
	Write-Host $projectFile.PSPath

	(Get-Content $projectFile.PSPath) |
	Foreach-Object { $_ -replace "<Version>\d\.\d\.\d+</Version>", "<Version>$version</Version>" } |
	Set-Content $projectFile.PSPath
}

# TODO: VC: Later include other params, e.g. Authors, Logo, etc... everything that is constant
# TODO: VC: For descriptions and keywords, create json file to keep all that info