using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface ICategoryFacilitiesService
    {
        ReturnEntity_IQueryable<CategoryFacilities> GetAllCategoryFacilities();
        ReturnEntity<CategoryFacilities> GetCategoryFacilitiesById(int id);
        Task<Result> CreateCategoryFacilities(CategoryFacilities categoryFacilities);
        Task<Result> DeleteCategoryFacilities(int id);
        Task<Result> EditCategoryFacilities(CategoryFacilities categoryFacilities);
    }
}
