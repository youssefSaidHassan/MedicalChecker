using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace MedicalChecker.Infrastructure.Seeder
{
    public static class DrugSeeder
    {
        public static void Seed(ApplicationDbContext _context, IWebHostEnvironment _env)
        {
            if (!_context.Drugs.Any())
            {
                var filePath = Path.Combine(_env.WebRootPath, "Jsons", "DrugData.json");

                var JsonData = File.ReadAllText(filePath);
                var drugData = JsonSerializer.Deserialize<List<DrugData>>(JsonData);

                foreach (var item in drugData)
                {
                    var drug = new Drug
                    {
                        Name = item.Drug_Name,
                        Description = item.Description
                    };
                    _context.Drugs.Add(drug);
                }
                _context.SaveChanges();

            }
        }
    }
    public class DrugData
    {
        public string Drug_Name { get; set; }
        public string Description { get; set; }
    }
}
