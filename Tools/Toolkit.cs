using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Toolkit
    {
        private static string _connectionString;

        public static string GetConnectionString()
        {
            if (_connectionString == null || _connectionString == "")
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("appSettings.json", optional: false);
                var configuration = builder.Build();
                _connectionString = configuration.GetConnectionString("testDB").ToString();
            }
            return _connectionString;
        }
    }
}
