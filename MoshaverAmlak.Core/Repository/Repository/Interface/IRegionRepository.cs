using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    interface IRegionRepository
    {
        ReturnEntity_IQueryable<Region> GetAllRegion();
        ReturnEntity<Region> GetRegionById(int regionId);
        Task<Result> CreateRegion(Region region);
        Task<Result> DeleteRegionById(int regionId);
        Task<Result> EditRegionById(Region region);

    }
}
