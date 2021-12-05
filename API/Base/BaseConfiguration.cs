using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Base
{
    public class BaseConfiguration
    {
        static IConfigurationRoot configRoot;

        public static IConfigurationRoot GetConfiguration()
        {

            if (configRoot != null)
            {
                return configRoot;

            }
            else
            {

                try
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                    var configBuilder = new ConfigurationBuilder();

                    configBuilder.AddJsonFile(path, false);

                    configRoot = configBuilder.Build();

                    return configRoot;


                }
                catch (Exception ex)
                {

                    throw ex;

                }

            }
        }



        public static string GetConnectionString
        {
            get
            {
                try
                {
                    var config = GetConfiguration();

                    return config.GetSection("ConnectionString").GetSection("connstring").Value;

                }
                catch (Exception ex) { throw ex; }

            }


        }
    }
}
