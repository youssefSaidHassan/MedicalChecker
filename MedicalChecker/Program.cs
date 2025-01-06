using MedicalChecker.Core;
using MedicalChecker.Infrastructure;
using MedicalChecker.Services;
using Serilog;
namespace MedicalChecker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Dependacy Injection
            builder.Services
                .AddServiceRegistration(builder.Configuration)
                .AddInfrastructureDependencies()
                .AddCoreDependencies()
                .AddServiceDependencies();
            #endregion

            Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(builder.Configuration).CreateLogger();
            builder.Services.AddSerilog();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
