Write-Host "Importing IIS Express certificate"

$certPath =  Resolve-Path 'IISExpressLocalhostCertificate.cer' # 'DevCert.pfx'
$password = 'DevCert99'

$certPathExists = Test-Path -Path $certPath

if(!$certPathExists)
{
	Write-Error -Message "Certificate path does not exist: $certPath"  -ErrorAction Stop
}

Import-Certificate -FilePath $certPath -CertStoreLocation 'Cert:\LocalMachine\My' -Verbose