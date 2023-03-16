using DSRPracticeProject.Api.Settings;
using DSRPracticeProject.Services.Books;
using DSRPracticeProject.Services.Settings;

namespace DSRPracticeProject.Api;
public static class Bootstrapper
{
    public static IServiceCollection AddAppServices(
        this IServiceCollection services)
    {
        services.AddMainSettings()
            .AddOpenApiSettings()
            .AddApiSpecialSettings()
            .AddBooksService();

        return services;
    }
}

