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
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _region;
        public RegionService(IRegionRepository region)
        {
            _region = region;
        }

        public ReturnEntity_IQueryable<Region> GetAllRegions() => _region.GetAllRegion();

        public ReturnEntity<Region> GetRegionById(int id) => _region.GetRegionById(id);
        public async Task<Result> CreateRegion(Region region) => await _region.CreateRegion(region);
        public async Task<Result> DeleteRegion(int id) => await _region.DeleteRegionById(id);

        public async Task<Result> EditRegion(Region region) => await
            _region.EditRegionById(region);
    }
}
