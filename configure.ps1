Write-Host "Starting updates..."

$filePath = 'template\\test\\Web\\Optivem.Template.Web.RestApi.IntegrationTest\\appsettings.Test.json'

Write-Host "File path is: $filePath"

$filePathExists = Test-Path -Path $filePath

if(!$filePathExists)
{
	Write-Error -Message "File path does not exist: $projectPath"  -ErrorAction Stop
}

$connection = 'Server=(local)\SQL2017;Database=Optivem.Template;User ID=sa;Password=Password12!;MultipleActiveResultSets=True;'

Write-Host "Connection is: $connection"

$json = (Get-Content -Path $filePath) | ConvertFrom-Json

Write-Host "JSON is: $json"

$json.ConnectionStrings.DefaultConnection = $connection

Write-Host "Updated JSON is $json"

$json | ConvertTo-Json | Set-Content $filePath

Write-Host "File has been updated"