using DSRPracticeProject.Context.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSRPracticeProject.Settings;
using DSRPracticeProject.Context.Factories;

namespace DSRPracticeProject.Context
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services,
            IConfiguration config = null)
        {
            var settings = DSRPracticeProject.Settings.Settings.Load<DbSettings>(
                "Database", config);
            services.AddSingleton(settings);

            var dbInitOptionsDelegate = DbContextOptionsFactory.Configure(
                settings.ConnectionString,
                settings.Type);

            services.AddDbContextFactory<MainDbContext>(dbInitOptionsDelegate);

            return services;
        }
    }
}
