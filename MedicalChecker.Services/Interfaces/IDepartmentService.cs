using MedicalChecker.Data.Entities;

namespace MedicalChecker.Services.Interfaces
{
    public interface IDepartmentService
    {

        Task<int> GetCountAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        //Task<Drug> GetDrugByIdAsync(int id);
        Task<bool> DepartmentExistByIdAsync(int id);
        Task<bool> IsNameExist(string name);
        Task<string> CreateAsync(Department dept);
        Task<string> UpdateAsync(Department dept);
        Task<string> DeleteAsync(Department dept);
        IQueryable<Department> FilterDepartmentsQuerable(string? search);

    }
}
