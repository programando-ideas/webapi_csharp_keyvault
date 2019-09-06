﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace webapi_csharp_keyvault
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                //if (context.HostingEnvironment.IsProduction())
                //{
                var builtConfig = config.Build();

                using (var store = new X509Store(StoreName.My,
                       StoreLocation.CurrentUser))
                {
                    //Obtenemos el Certificado
                    store.Open(OpenFlags.ReadOnly);
                    var certs = store.Certificates
                        .Find(X509FindType.FindByThumbprint, builtConfig["AzureADCertThumbprint"], false);

                    try
                    {
                        //Nos conectamos a Azure Key Vault API
                        var certificados = certs.OfType<X509Certificate2>();
                        config.AddAzureKeyVault($"https://{builtConfig["KeyVaultName"]}.vault.azure.net/",
                                                builtConfig["AzureADApplicationId"], certificados.First());
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                    store.Close();
                }
                //}
            })
                .UseStartup<Startup>();
    }
}
