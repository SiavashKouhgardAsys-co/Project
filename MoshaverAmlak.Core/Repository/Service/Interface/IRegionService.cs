using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IRegionService
    {
        ReturnEntity_IQueryable<Region> GetAllRegions();
        ReturnEntity<Region> GetRegionById(int id);
        Task<Result> CreateRegion(Region region);
        Task<Result> DeleteRegion(int id);
        Task<Result> EditRegion(Region region);
    }
}
