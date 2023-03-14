using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

namespace DSRPracticeProject.Api.Configuration.HealthChecks
{
    public class SelfHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            Assembly assembly = Assembly.Load("DSRPracticeProject.Api");
            Version? versionNumber = assembly.GetName().Version;

            return Task.FromResult(HealthCheckResult.Healthy(
                description: $"Build {versionNumber}"));
        }
    }
}
