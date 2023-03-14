using DSRPracticeProject.Context.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPracticeProject.Context.Factories
{
    public class DesignTimeDbContextFactory
    {
        private const string migrationProjectPrefix = "DSRPracticeProject.Migrations";

        public MainDbContext CreateDbContext(string[] args)
        {
            string provider = (args?[0] ?? DbType.MSSQL.ToString()).ToLower();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.context.json")
                .Build();

            DbContextOptions<MainDbContext> options;
            if (provider.Equals($"{DbType.MSSQL}".ToLower()))
            {
                options = new DbContextOptionsBuilder<MainDbContext>()
                        .UseSqlServer(
                            configuration.GetConnectionString(provider),
                            opts => opts
                                .MigrationsAssembly($"{migrationProjectPrefix}{DbType.MSSQL}")
                        )
                        .Options;
            }
            else
            if (provider.Equals($"{DbType.PostgreSQL}".ToLower()))
            {
                options = new DbContextOptionsBuilder<MainDbContext>()
                        .UseNpgsql(
                            configuration.GetConnectionString(provider),
                            opts => opts
                                .MigrationsAssembly($"{migrationProjectPrefix}{DbType.PostgreSQL}")
                        )
                        .Options;
            }
            else
            {
                throw new Exception($"Unsupported provider: {provider}");
            }

            var dbf = new DbContextFactory(options);
            return dbf.Create();
        }
    }
}
