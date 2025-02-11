using MedicalChecker.Data.Entities;

namespace MedicalChecker.Services.Interfaces
{
    public interface IDrugService
    {
        IQueryable<Drug> FilterDrugsQuerable(string? search);
        Task<int> GetCountAsync();
        Task<Drug> GetDrugByIdAsync(int id);
        Task<bool> DrugExistByIdAsync(int id);
        Task<bool> IsNameExist(string name);
        Task<string> CreateAsync(Drug drug);
        Task<string> UpdateAsync(Drug drug);
        Task<string> DeleteAsync(Drug drug);
    }
}
