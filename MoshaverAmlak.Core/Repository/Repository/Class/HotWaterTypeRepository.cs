using System;
using System.Threading.Tasks;
using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class HotWaterTypeRepository : IHotWaterTypeRepository
    {
        private readonly IGenericRepository<HotWaterType> _hotWaterTypeRepository;

        public HotWaterTypeRepository(IGenericRepository<HotWaterType> hotWaterTypeRepository)
        {
            _hotWaterTypeRepository = hotWaterTypeRepository;
        }

        public ReturnEntity_IQueryable<HotWaterType> GetAllHotWaterType() => _hotWaterTypeRepository.GetAllEntity();
        public ReturnEntity<HotWaterType> GetHotWaterTypeById(int hotWaterTypeId) => _hotWaterTypeRepository.GetEntityById(hotWaterTypeId);
        public async Task<Result> CraeteHotWaterType(HotWaterType hotWaterType)
        {
            var entity = _hotWaterTypeRepository.AddEntity(hotWaterType);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _hotWaterTypeRepository.SaveChangeAsync();
        }
        public async Task<Result> DeleteHotWaterTypeById(int hotWaterTypeId)
        {
            var entity = _hotWaterTypeRepository.DeleteEntityById(hotWaterTypeId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _hotWaterTypeRepository.SaveChangeAsync();
        }
        public async Task<Result> UpdateHotWaterTypeById(HotWaterType hotWaterType)
        {
            var entity = GetHotWaterTypeById(hotWaterType.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = hotWaterType.Name;
            var update_entity = _hotWaterTypeRepository.UpdateEntity(entity.Entity);
            if (update_entity.StatusResult != (int)Result.Status.OK) return update_entity;
            return await _hotWaterTypeRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _hotWaterTypeRepository?.Dispose();
        }
    }
}
