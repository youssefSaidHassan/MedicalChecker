using Microsoft.Extensions.DependencyInjection;

namespace MedicalChecker.Services
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
