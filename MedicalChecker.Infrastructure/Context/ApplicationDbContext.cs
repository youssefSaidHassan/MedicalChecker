using MedicalChecker.Data.Entities;
using MedicalChecker.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MedicalChecker.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<SocialLinks> SocialLinks { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Precautions> Precautions { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<DiseasePrecaution> DiseasePrecautions { get; set; }

    }
}
