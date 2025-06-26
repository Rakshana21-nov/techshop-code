using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace TechShop.utility
{
    public static class DBPropertyUtil
    {
        private static readonly string propertyFileName = "appsettings.json";

        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(AppContext.BaseDirectory)
                            .AddJsonFile(propertyFileName);

            IConfiguration configuration = builder.Build();

            return configuration.GetConnectionString("LocalConnectionString");
        }
    }
}

