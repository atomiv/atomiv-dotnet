Write-Host "Starting updates..."

$filePath = 'template\\test\\Web\\RestApi.IntegrationTest\\appsettings.Test.json'

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

$Env:ASPNETCORE_ENVIRONMENT="Staging"

Write-Host "Set ENVIRONMENT"

Write-Host "Trusting HTTPS certificates"

# Note: https://stackoverflow.com/questions/49428317/vsts-iis-deploy-configure-iis-site-ssl-certificates/49444664#49444664

# $pfxpath = 'DevCert.pfx'
$pfxpath = 'DevCert'
$password = 'DevCert99'

$certPathExists = Test-Path -Path $pfxpath

if(!$certPathExists)
{
	Write-Error -Message "Certificate path does not exist: $pfxpath"  -ErrorAction Stop
}

Add-Type -AssemblyName System.Security
$cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2
$cert.Import($pfxpath, $password, [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]"PersistKeySet")
$store = new-object system.security.cryptography.X509Certificates.X509Store -argumentlist "MY", CurrentUser
$store.Open([System.Security.Cryptography.X509Certificates.OpenFlags]"ReadWrite")
$store.Add($cert)
$store.Close()