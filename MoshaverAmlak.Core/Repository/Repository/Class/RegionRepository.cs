using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    class RegionRepository
    {
        private readonly IGenericRepository<Region> _regionRepository;
        public RegionRepository(IGenericRepository<Region> regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public ReturnEntity_IQueryable<Region> GetAllRegion() => _regionRepository.GetAllEntity();
        public ReturnEntity<Region> GetRegionById(int regionId) => _regionRepository.GetEntityById(regionId);

        public async Task<Result> CreateRegion(Region region)
        {
            var entity = _regionRepository.AddEntity(region);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _regionRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteRegionById(int regionId)
        {
            var entity = _regionRepository.DeleteEntityById(regionId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _regionRepository.SaveChangeAsync();
        }

        public async Task<Result> EditRegionById(Region region)
        {
            var entity = _regionRepository.GetEntityById(region.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = region.Name;
            var updateEntity = _regionRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _regionRepository.SaveChangeAsync();
        }
    }
}
