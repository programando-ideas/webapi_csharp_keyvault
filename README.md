# PROGRAMANDO IDEAS
### [Canal de YouTube](https://www.youtube.com/channel/UCr-7aJpOx7a78nHFz70Ri2Q)

## webapi_csharp_keyvault

Azure Key Vault con ASP.NET Core WebApi C#

### Comando para crear certificado

```
New-SelfSignedCertificate -Type Custom -KeySpec Signature -Subject "CN=programando_ideas_cert" -KeyExportPolicy Exportable -HashAlgorithm sha256 -KeyLength 2048 -CertStoreLocation "Cert:\CurrentUser\My" -KeyUsageProperty Sign -KeyUsage CertSign
```
