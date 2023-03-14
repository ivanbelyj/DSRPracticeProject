using DSRPracticeProject.Api.Configuration.HealthChecks;
using DSRPracticeProject.Common.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace DSRPracticeProject.Api.Configuration
{
    public static class HealthCheckConfiguration
    {
        public static IServiceCollection AddAppHealthChecks(
            this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<SelfHealthCheck>("DSRPracticeProject.Api");
            return services;
        }

        public static void UseAppHealthChecks(
            this WebApplication app)
        {
            app.MapHealthChecks("/health");

            app.MapHealthChecks("/health/detail", new HealthCheckOptions()
            {
                ResponseWriter = HealthCheckHelper.WriteHealthCheckResponseAsync,
                AllowCachingResponses = false
            });
        }
    }
}
