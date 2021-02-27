using System.Threading.Tasks;
using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class FacilitiesRepository : IFacilitiesRepository
    {
        private readonly IGenericRepository<Facilities> _facilitiesRepository;

        public FacilitiesRepository(IGenericRepository<Facilities> facilitiesRepository)
        {
            _facilitiesRepository = facilitiesRepository;
        }

        public ReturnEntity_IQueryable<Facilities> GetAllFacilities() => _facilitiesRepository.GetAllEntity();
        public ReturnEntity<Facilities> GetFacilityById(int facilityId) => _facilitiesRepository.GetEntityById(facilityId);
        public async Task<Result> CreateFacility(Facilities facilities)
        {
            var entity = await _facilitiesRepository.AddEntity(facilities);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _facilitiesRepository.SaveChangeAsync();
        }
        public async Task<Result> DeleteFacilityById(int facilityId)
        {
            var entity = _facilitiesRepository.DeleteEntityById(facilityId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _facilitiesRepository.SaveChangeAsync();
        }
        public async Task<Result> EditFacility(Facilities facilities)
        {
            var entity = GetFacilityById(facilities.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = facilities.Name;
            entity.Entity.CategoryFacilityId = facilities.CategoryFacilityId;
            var update_entity = _facilitiesRepository.UpdateEntity(entity.Entity);
            if (update_entity.StatusResult != (int)Result.Status.OK) return update_entity;
            return await _facilitiesRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _facilitiesRepository?.Dispose();
        }
    }
}
