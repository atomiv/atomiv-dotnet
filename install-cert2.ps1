# SOURCE: https://stackoverflow.com/questions/53771022/how-to-create-and-install-x-509-self-signed-certificates-in-windows-10-without-u

#
# This script will create and install two certificates:
#     1. `MyCA.cer`: A self-signed root authority certificate. 
#     2. `MySPC.cer`: The cerificate to sign code in 
#         a development environment (signed with `MyCA.cer`).
# 
# No user interaction is needed (unattended). 
# Powershell 4.0 or higher is required.
#

# Define the expiration date for certificates.
$notAfter = (Get-Date).AddYears(10)

# Create a self-signed root Certificate Authority (CA).
$rootCert = New-SelfSignedCertificate -KeyExportPolicy Exportable -CertStoreLocation Cert:\CurrentUser\My -DnsName "My CA" -NotAfter $notAfter -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.3", "2.5.29.19={text}CA=1") -KeyusageProperty All -KeyUsage CertSign, CRLSign, DigitalSignature

# Export the CA private key.
[System.Security.SecureString] $password = ConvertTo-SecureString -String "passwordx" -Force -AsPlainText
[String] $rootCertPath = Join-Path -Path cert:\CurrentUser\My\ -ChildPath "$($rootcert.Thumbprint)"
Export-PfxCertificate -Cert $rootCertPath -FilePath "MyCA.pfx" -Password $password
Export-Certificate -Cert $rootCertPath -FilePath "MyCA.crt"

# Create an end certificate signed by our CA.
$cert = New-SelfSignedCertificate -CertStoreLocation Cert:\LocalMachine\My -DnsName "My Company Name" -NotAfter $notAfter -Signer $rootCert -Type CodeSigningCert -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.3", "2.5.29.19={text}CA=0&pathlength=0")

# Save the signed certificate with private key into a PFX file and just the public key into a CRT file.
[String] $certPath = Join-Path -Path cert:\LocalMachine\My\ -ChildPath "$($cert.Thumbprint)"
Export-PfxCertificate -Cert $certPath -FilePath "MySPC.pfx" -Password $password
Export-Certificate -Cert $certPath -FilePath "MySPC.crt"

# Add MyCA certificate to the Trusted Root Certification Authorities.
$pfx = new-object System.Security.Cryptography.X509Certificates.X509Certificate2
$pfx.import("MyCA.pfx", $password, "Exportable,PersistKeySet")
$store = new-object System.Security.Cryptography.X509Certificates.X509Store(
    [System.Security.Cryptography.X509Certificates.StoreName]::Root,
    "localmachine"
)
$store.open("MaxAllowed")
$store.add($pfx)
$store.close()

# Remove MyCA from CurrentUser to avoid issues when signing with "signtool.exe /a ..."
Remove-Item -Force "cert:\CurrentUser\My\$($rootCert.Thumbprint)"

# Import certificate.
Import-PfxCertificate -FilePath MySPC.pfx cert:\CurrentUser\My -Password $password -Exportable