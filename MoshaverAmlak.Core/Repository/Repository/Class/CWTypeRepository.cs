using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    class CWTypeRepository : ICWTypeRepository
    {
        private readonly IGenericRepository<CWType> _cwTypeRepository;
        public CWTypeRepository(IGenericRepository<CWType> cwTypeRepository)
        {
            _cwTypeRepository = cwTypeRepository;
        }

        public ReturnEntity_IQueryable<CWType> GetAllCWType() => _cwTypeRepository.GetAllEntity();
        public ReturnEntity<CWType> GetCWTypeById(int cwTypeRepository) => _cwTypeRepository.GetEntityById(cwTypeRepository);

        public async Task<Result> CreateCWType(CWType cWType)
        {
            var entity = _cwTypeRepository.AddEntity(cWType);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _cwTypeRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteCWTypeById(int cwTypeId)
        {
            var entity = _cwTypeRepository.DeleteEntityById(cwTypeId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _cwTypeRepository.SaveChangeAsync();
        }

        public async Task<Result> EditCWType(CWType cWType)
        {
            var entity = _cwTypeRepository.GetEntityById(cWType.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = cWType.Name;
            var updateEntity = _cwTypeRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _cwTypeRepository.SaveChangeAsync();
        }
        public void Dispose()
        {
            _cwTypeRepository?.Dispose();
        }
    }
}
