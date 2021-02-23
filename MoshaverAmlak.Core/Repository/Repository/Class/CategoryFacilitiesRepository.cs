using System.Threading.Tasks;
using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class CategoryFacilitiesRepository : ICategoryFacilitiesRepository
    {
        private readonly IGenericRepository<CategoryFacilities> _categoryFacilitiesRepository;
        public CategoryFacilitiesRepository(IGenericRepository<CategoryFacilities> categoryFacilitiesRepository)
        {
            _categoryFacilitiesRepository = categoryFacilitiesRepository;
        }

        public ReturnEntity_IQueryable<CategoryFacilities> GetAllCategoryFacilities() => _categoryFacilitiesRepository.GetAllEntity();

        public ReturnEntity<CategoryFacilities> GetCategoryFacilitiesById(int categoryFacilitiesId) => _categoryFacilitiesRepository.GetEntityById(categoryFacilitiesId);

        public async Task<Result> CreateCategoryFacilities(CategoryFacilities categoryFacilities)
        {
            var entity = await _categoryFacilitiesRepository.AddEntity(categoryFacilities);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _categoryFacilitiesRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteCategoryFacilitiesById(int categoryFacilitiesId)
        {
            var entity = _categoryFacilitiesRepository.DeleteEntityById(categoryFacilitiesId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _categoryFacilitiesRepository.SaveChangeAsync();
        }

        public async Task<Result> EditCategoryFacilities(CategoryFacilities  categoryFacilities)
        {
            var entity = GetCategoryFacilitiesById(categoryFacilities.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = categoryFacilities.Name;
            var update_entity = _categoryFacilitiesRepository.UpdateEntity(entity.Entity);
            if (update_entity.StatusResult != (int)Result.Status.OK) return update_entity;
            return await _categoryFacilitiesRepository.SaveChangeAsync();
        }


        public void Dispose()
        {
            _categoryFacilitiesRepository?.Dispose();
        }

    }
}
