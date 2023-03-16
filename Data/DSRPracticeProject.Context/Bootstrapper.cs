namespace DSRPracticeProject.Context;

using DSRPracticeProject.Context.Factories;
using DSRPracticeProject.Context.Settings;
using DSRPracticeProject.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services,
        IConfiguration configuration = null)
    {
        var settings = DSRPracticeProject.Settings
            .Settings.Load<DbSettings>("Database", configuration);
        services.AddSingleton(settings);

        var dbInitOptionsDelegate = DbContextOptionsFactory.Configure(
            settings.ConnectionString,
            settings.Type);

        services.AddDbContextFactory<MainDbContext>(dbInitOptionsDelegate);

        return services;
    }
}
