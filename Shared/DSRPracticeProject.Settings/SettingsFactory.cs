using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPracticeProject.Settings
{
    public static class SettingsFactory
    {
        public static IConfiguration Create(
            IConfiguration? configuration = null)
        {
            return configuration ?? new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
