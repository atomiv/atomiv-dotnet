# Parameters

param (
	[string]$rootPath = '.',
	[string]$relative = 'pck\\content',
	[Parameter(Mandatory=$true)][string]$version = '0.0.0'
)


$combined = Join-Path $rootPath $relative

$fullPath = Resolve-Path $combined

Write-Host $fullPath

# Upgrade project version

$projectFiles = Get-ChildItem $fullPath *.csproj -rec
foreach($projectFile in $projectFiles)
{
	Write-Host $projectFile
	
	# Write-Host $projectFile.PSPath
	
	$lines = Get-Content $projectFile.PSPath
	
	for($i = 0; $i -lt $lines.Length; $i++) {
		$line = $lines[$i]
		# Write-Host $line
	
		if($line -like '*ProjectReference*' -and $line -like '*Atomiv*' -and $line -notlike '*Atomiv.Template*') {
		
			Write-Host "Line: " $line
		
			$indexStart = $line.IndexOf('Atomiv')
			$indexEnd = $line.IndexOf('.csproj')
			
			$length = $indexEnd - $indexStart
			$name = $line.SubString($indexStart, $length);
			# Write-Host "Name: " $name
			
			$linePartIndexStart = $line.IndexOf('<ProjectReference')
			$linePartIndexEnd = $line.IndexOf('>')
			
			$linePartLength = $linePartIndexEnd - $linePartIndexStart
			$linePart =  $line.SubString($linePartIndexStart, $linePartLength)
			
			$replacementLine = '<PackageReference Include="' + $name + '" Version="' + $version + '" />'
			
			Write-Host "Replacement: " $replacementLine
			
			$lines[$i] = $replacementLine
		}
	}
	
	Set-Content -Path $projectFile.PSPath -Value $lines
}



