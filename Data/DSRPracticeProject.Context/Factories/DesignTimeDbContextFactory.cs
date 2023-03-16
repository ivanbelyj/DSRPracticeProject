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
        private const string migrationProjectPrefix = "DSRPracticeProject.Context.Migrations";

        public MainDbContext CreateDbContext(string[] args)
        {
            if (args.Length < 1)
                throw new ArgumentException("No required argument");
            string provider = args[0].ToLower();

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
            else if (provider.Equals($"{DbType.PostgreSQL}".ToLower()))
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
