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

$certPath = 'DevCert' # 'DevCert.pfx'
$password = 'DevCert99'

$certPathExists = Test-Path -Path $certPath

if(!$certPathExists)
{
	Write-Error -Message "Certificate path does not exist: $certPath"  -ErrorAction Stop
}

$securePassword = ConvertTo-SecureString $password -asplaintext -force

Import-PfxCertificate -FilePath $certPath -CertStoreLocation Cert:\LocalMachine\My -Password $securePassword

Write-Host "Trying to run web api"

dotnet run --project .\template\src\Web\RestApi\Optivem.Template.Web.RestApi.csproj --environment Staging