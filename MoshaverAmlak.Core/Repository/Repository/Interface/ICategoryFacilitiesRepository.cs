﻿using System;
using System.Threading.Tasks;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface ICategoryFacilitiesRepository : IDisposable
    {
        ReturnEntity_IQueryable<CategoryFacilities> GetAllCategoryFacilities();
        ReturnEntity<CategoryFacilities> GetCategoryFacilitiesById(int categoryFacilitiesId);
        Task<Result> CreateCategoryFacilities(CategoryFacilities categoryFacilities);
        Task<Result> DeleteCategoryFacilitiesById(int categoryFacilitiesId);
        Task<Result> EditCategoryFacilities(CategoryFacilities categoryFacilities);


    }
}
