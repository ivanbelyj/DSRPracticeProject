using DSRPracticeProject.Common.Helpers;

namespace DSRPracticeProject.Api.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAppAutoMappers(this IServiceCollection services)
        {
            AutoMapperRegisterHelper.Register(services);

            return services;
        }
    }
}
