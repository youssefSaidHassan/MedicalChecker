﻿using MedicalChecker.Services.Implementation;
using MedicalChecker.Services.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalChecker.Services
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IDrugService, DrugService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
