using MedicalChecker.Infrastructure.Generic;
using MedicalChecker.Infrastructure.Interfaces;
using MedicalChecker.Infrastructure.Repositories;
using MedicalChecker.Infrastructure.UnitWork;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalChecker.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDiseasePrecautionRepository, DiseasePrecautionRepository>();
            services.AddScoped<IDiseaseRepository, DiseaseRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDrugRepository, DrugRepository>();
            services.AddScoped<IPrecautionsRepository, PrecautionsRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<ISocialLinksRepository, SocialLinksRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
