using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.UnitWork;
using MedicalChecker.Services.Interfaces;
using MedicalChecker.Utility.AppMetaData;
using Microsoft.EntityFrameworkCore;

namespace MedicalChecker.Services.Implementation
{
    public class DrugService : IDrugService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public DrugService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        #endregion

        #region Handel Functions
        public async Task<bool> DrugExistByIdAsync(int id)
        {
            var result = await _unitOfWork.Drug.GetByIdAsync(id);
            return result != null;
        }
        public IQueryable<Drug> FilterDrugsQuerable(string? search)
        {
            var querable = _unitOfWork.Drug.GetTableNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(search))
                querable = querable.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            return querable;
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.Drug.GetTableNoTracking().CountAsync();
        }

        public async Task<Drug> GetDrugByIdAsync(int id)
        {
            return await _unitOfWork.Drug.GetByIdAsync(id);
        }

        public async Task<bool> IsNameExist(string name)
        {
            var result = await _unitOfWork.Drug.GetTableNoTracking().Where(x => x.Name.ToLower().Equals(name.ToLower())).FirstOrDefaultAsync();
            return result != null;
        }
        public async Task<string> CreateAsync(Drug drug)
        {
            try
            {
                await _unitOfWork.Drug.AddAsync(drug);
                return SD.Success;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UpdateAsync(Drug drug)
        {
            try
            {
                await _unitOfWork.Drug.UpdateAsync(drug);
                return SD.Success;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteAsync(Drug drug)
        {
            try
            {
                await _unitOfWork.Drug.DeleteAsync(drug);
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
