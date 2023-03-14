using DSRPracticeProject.Context.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPracticeProject.Context.Factories
{
    public static class DbContextOptionsFactory
    {
        private const string migrationProjectPrefix = "DSRPracticeProject.Migrations";

        public static DbContextOptions<MainDbContext> Create(string connString,
            DbType dbType)
        {
            var builder = new DbContextOptionsBuilder<MainDbContext>();
            Configure(connString, dbType).Invoke(builder);
            return builder.Options;
        }

        public static Action<DbContextOptionsBuilder> Configure(
            string connString, DbType dbType)
        {
            return (DbContextOptionsBuilder builder) =>
            {
                const string migrationsHistoryTableName = "_EFMigrationsHistory";
                switch (dbType)
                {
                    case DbType.PostgreSQL:
                        builder.UseNpgsql(connString,
                            opts => opts
                                .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
                                .MigrationsHistoryTable(migrationsHistoryTableName, "public")
                                .MigrationsAssembly($"{migrationProjectPrefix}{DbType.MSSQL}")
                            );
                        break;
                    case DbType.MSSQL:
                        builder.UseSqlServer(connString,
                            opts => opts
                                .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
                                .MigrationsHistoryTable(migrationsHistoryTableName, "public")
                                .MigrationsAssembly($"{migrationProjectPrefix}{DbType.MSSQL}")
                            );
                        break;
                }
                builder.EnableSensitiveDataLogging();
                builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            };
        } 
    }
}
