using Microsoft.Extensions.DependencyInjection;

namespace MedicalChecker.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
