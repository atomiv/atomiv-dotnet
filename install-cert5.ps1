# Source: https://www.humankode.com/asp-net-core/develop-locally-with-https-self-signed-certificates-and-asp-net-core

Write-Host "Generating Localhost Certificate for .NET Core..."

# setup certificate properties including the commonName (DNSName) property for Chrome 58+
$certificate = New-SelfSignedCertificate `
    -Subject localhost `
    -DnsName localhost `
    -KeyAlgorithm RSA `
    -KeyLength 2048 `
    -NotBefore (Get-Date) `
    -NotAfter (Get-Date).AddYears(2) `
    -CertStoreLocation "cert:LocalMachine\My" `
    -FriendlyName "Localhost3 Certificate for .NET Core" `
    -HashAlgorithm SHA256 `
    -KeyUsage DigitalSignature, KeyEncipherment, DataEncipherment `
    -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.1") 
$certificatePath = 'Cert:\LocalMachine\My\' + ($certificate.ThumbPrint)  

# create temporary certificate path
# $tmpPath = "C:\tmp"
<#
If(!(test-path $tmpPath))
{
New-Item -ItemType Directory -Force -Path $tmpPath
}
#>

# set certificate password here
$pfxPassword = ConvertTo-SecureString -String "YourSecurePassword" -Force -AsPlainText
$pfxFilePath = "C:\projects\framework-dotnetcore\template\src\Web\UI\localhost3.pfx"
$cerFilePath = "C:\projects\framework-dotnetcore\template\src\Web\UI\localhost3.cer"
#$pfxFilePath = "D:\GitHub\optivem\framework-dotnetcore\template\src\Web\UI\localhost3.pfx"
#$cerFilePath = "D:\GitHub\optivem\framework-dotnetcore\template\src\Web\UI\localhost3.cer"

Write-Host "Exporting..."

# create pfx certificate
Export-PfxCertificate -Cert $certificatePath -FilePath $pfxFilePath -Password $pfxPassword
Export-Certificate -Cert $certificatePath -FilePath $cerFilePath

Write-Host "Importing..."

# import the pfx certificate
Import-PfxCertificate -FilePath $pfxFilePath Cert:\LocalMachine\My -Password $pfxPassword -Exportable

# trust the certificate by importing the pfx certificate into your trusted root
# TODO: VC: Check if needed
# Import-Certificate -FilePath $cerFilePath -CertStoreLocation Cert:\CurrentUser\Root



# https://social.technet.microsoft.com/Forums/ie/en-US/aac8cfcd-6bd2-423f-895b-a6612459eb16/importcertificate-without-confirmation-ignore-security-warnings?forum=winserverpowershell

$cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($cerFilePath)
$rootStore = Get-Item Cert:\LocalMachine\Root
$rootStore.Open("ReadWrite")
$rootStore.Add($cert)
$rootStore.Close()



# optionally delete the physical certificates (don’t delete the pfx file as you need to copy this to your app directory)
# Remove-Item $pfxFilePath
Remove-Item $cerFilePath

Write-Host "Finished."