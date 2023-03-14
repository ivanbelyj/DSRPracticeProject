using DSRPracticeProject.Common;

namespace DSRPracticeProject.Api.Configuration
{
    public static class ControllersAndViewsConfiguration
    {
        public static IServiceCollection AddAppControllersAndViews(
            this IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.SetDefaultSettings();
                });

            return services;
        }

        public static IEndpointRouteBuilder UseAppControllersAndViews(
            this IEndpointRouteBuilder builder)
        {
            builder.MapRazorPages();
            builder.MapControllers();

            return builder;
        }
    }
}
