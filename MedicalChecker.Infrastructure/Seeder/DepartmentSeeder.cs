using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace MedicalChecker.Infrastructure.Seeder
{
    public static class DepartmentSeeder
    {
        public static void Seed(ApplicationDbContext _context, IWebHostEnvironment _env)
        {
            if (!_context.Departments.Any())
            {
                var filePath = Path.Combine(_env.WebRootPath, "Jsons", "DepartmentsData.json");

                var JsonData = File.ReadAllText(filePath);
                var departmentData = JsonSerializer.Deserialize<List<DepartmentsData>>(JsonData);

                foreach (var item in departmentData)
                {
                    var department = new Department
                    {
                        Name = item.name,
                    };
                    _context.Departments.Add(department);
                }
                _context.SaveChanges();

            }
        }

    }
    public class DepartmentsData
    {
        public string name { get; set; }
    }
}
