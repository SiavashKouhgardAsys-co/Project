using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class CategoryFacilitiesService : ICategoryFacilitiesService
    {
        private readonly ICategoryFacilitiesRepository _categoryFacilities;
        public CategoryFacilitiesService(ICategoryFacilitiesRepository categoryFacilities)
        {
            _categoryFacilities = categoryFacilities;
        }

        public ReturnEntity_IQueryable<CategoryFacilities> GetAllCategoryFacilities() => _categoryFacilities.GetAllCategoryFacilities();

        public ReturnEntity<CategoryFacilities> GetCategoryFacilitiesById(int id) => _categoryFacilities.GetCategoryFacilitiesById(id);

        public async Task<Result> CreateCategoryFacilities(CategoryFacilities categoryFacilities) => await _categoryFacilities.CreateCategoryFacilities(categoryFacilities);
        public async Task<Result> DeleteCategoryFacilities(int id) => await _categoryFacilities.DeleteCategoryFacilitiesById(id);

        public async Task<Result> EditCategoryFacilities(CategoryFacilities categoryFacilities) => await
            _categoryFacilities.EditCategoryFacilities(categoryFacilities);
    }
}
