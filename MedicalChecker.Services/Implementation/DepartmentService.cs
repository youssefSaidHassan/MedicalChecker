using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.UnitWork;
using MedicalChecker.Services.Interfaces;
using MedicalChecker.Utility.AppMetaData;
using Microsoft.EntityFrameworkCore;

namespace MedicalChecker.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        #endregion

        #region Handel Functions


        public IQueryable<Department> FilterDepartmentsQuerable(string? search)
        {
            var querable = _unitOfWork.Department.GetTableNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
                querable = querable.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            return querable;
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.Department.GetTableNoTracking().CountAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _unitOfWork.Department.GetByIdAsync(id);
        }

        public async Task<bool> IsNameExist(string name)
        {
            var result = await _unitOfWork.Department.GetTableNoTracking().Where(x => x.Name.ToLower().Equals(name.ToLower())).FirstOrDefaultAsync();

            return result != null;
        }
        public async Task<bool> DepartmentExistByIdAsync(int id)
        {
            var result = await GetDepartmentByIdAsync(id);
            return result != null;
        }
        public async Task<string> CreateAsync(Department dept)
        {
            try
            {
                await _unitOfWork.Department.AddAsync(dept);
                return SD.Success;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        public async Task<string> UpdateAsync(Department dept)
        {
            try
            {
                await _unitOfWork.Department.UpdateAsync(dept);
                return SD.Success;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteAsync(Department dept)
        {
            try
            {
                await _unitOfWork.Department.DeleteAsync(dept);
                return SD.Success;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}
