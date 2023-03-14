namespace DSRPracticeProject.Services.Settings;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using DSRPracticeProject.Settings;

public static class Bootstrapper
{
    public static IServiceCollection AddMainSettings(
        this IServiceCollection services,
        IConfiguration configuration = null)
    {
        var settings = Settings.Load<MainSettings>("Main", configuration);
        services.AddSingleton(settings);

        return services;
    }

    public static IServiceCollection AddOpenApiSettings(
        this IServiceCollection services,
        IConfiguration configuration = null)
    {
        var settings = Settings.Load<OpenApiSettings>("OpenApi", configuration);
        services.AddSingleton(settings);

        return services;
    }
}