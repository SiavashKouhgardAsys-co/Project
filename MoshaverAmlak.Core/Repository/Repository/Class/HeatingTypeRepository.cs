using System.Threading.Tasks;
using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class HeatingTypeRepository : IHeatingTypeRepository
    {
        private readonly IGenericRepository<HeatingType> _heatingTypeRepository;
        public HeatingTypeRepository(IGenericRepository<HeatingType> heatingTypeRepository)
        {
            _heatingTypeRepository = heatingTypeRepository;
        }

        public ReturnEntity_IQueryable<HeatingType> GetAllHeatingType() => _heatingTypeRepository.GetAllEntity();
        public ReturnEntity<HeatingType> GetHeatingTypeById(int heatingTypeId) => _heatingTypeRepository.GetEntityById(heatingTypeId);
        public async Task<Result> CreateHeatingType(HeatingType heatingType)
        {
            var entity = _heatingTypeRepository.AddEntity(heatingType);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _heatingTypeRepository.SaveChangeAsync();
        }
        public async Task<Result> UpdateHeatingType(HeatingType heatingType)
        {
            var entity = GetHeatingTypeById(heatingType.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = heatingType.Name;
            var update_entity = _heatingTypeRepository.UpdateEntity(entity.Entity);
            if (update_entity.StatusResult != (int)Result.Status.OK) return update_entity;
            return await _heatingTypeRepository.SaveChangeAsync();
        }
        public async Task<Result> DeleteHeatingType(int heatingTypeId)
        {
            var entity = _heatingTypeRepository.DeleteEntityById(heatingTypeId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _heatingTypeRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _heatingTypeRepository?.Dispose();
        }
    }
}
