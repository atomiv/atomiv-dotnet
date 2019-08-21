Write-Host "Trusting HTTPS certificates"

$certPath =  Resolve-Path 'DevCert' # 'DevCert.pfx'
$password = 'DevCert99'

$certPathExists = Test-Path -Path $certPath

if(!$certPathExists)
{
	Write-Error -Message "Certificate path does not exist: $certPath"  -ErrorAction Stop
}

$securePassword = ConvertTo-SecureString $password -asplaintext -force

Import-PfxCertificate -FilePath $certPath -CertStoreLocation Cert:\LocalMachine\My -Password $securePassword


function Install-Certificate ($certificatePath, $certificatePassword, [string]$storeLocation = "LocalMachine", [string]$storeName = "My")
{
    $cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($certificatePath, $certificatePassword, "MachineKeySet,PersistKeySet")
    $store = New-Object System.Security.Cryptography.X509Certificates.X509Store($storeName, $storeLocation)
    $store.Open("ReadWrite")
    $store.Add($cert)
    $store.Close()
    "Thumbprint: $($cert.Thumbprint)"
}

Install-Certificate $certPath $securePassword



# TODO: VC: DELETE
# Write-Host "Trying to run web api"
# dotnet run --project .\template\src\Web\RestApi\Optivem.Template.Web.RestApi.csproj --environment Staging