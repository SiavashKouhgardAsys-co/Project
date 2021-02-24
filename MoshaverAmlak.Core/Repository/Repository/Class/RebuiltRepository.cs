using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System.Threading.Tasks;


namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class RebuiltRepository : IRebuiltRepository
    {
        private readonly IGenericRepository<Rebuilt> _rebuiltRepository;
        public RebuiltRepository(IGenericRepository<Rebuilt> rebuiltRepository)
        {
            _rebuiltRepository = rebuiltRepository;
        }

        public ReturnEntity_IQueryable<Rebuilt> GetAllRebuilt() => _rebuiltRepository.GetAllEntity();
        public ReturnEntity<Rebuilt> GetRebuiltById(int rebuiltId) => _rebuiltRepository.GetEntityById(rebuiltId);

        public async Task<Result> CreateRebuilt(Rebuilt rebuilt)
        {
            var entity = await _rebuiltRepository.AddEntity(rebuilt);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _rebuiltRepository.SaveChangeAsync();

        }

        public async Task<Result> DeleteRebuiltById(int rebuiltId)
        {
            var entity = _rebuiltRepository.DeleteEntityById(rebuiltId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _rebuiltRepository.SaveChangeAsync();
        }

        public async Task<Result> EditRebuilt(Rebuilt rebuilt)
        {
            var entity = GetRebuiltById(rebuilt.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = rebuilt.Name;
            var updateEntity = _rebuiltRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _rebuiltRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _rebuiltRepository?.Dispose();
        }
    }
}
