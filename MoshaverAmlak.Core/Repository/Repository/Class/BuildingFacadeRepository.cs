using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    class BuildingFacadeRepository : IBuildingFacadeRepository
    {
        private readonly IGenericRepository<BuildingFacade> _buildingFacadeRepository;
        public ReturnEntity_IQueryable<BuildingFacade> GetAllBuildingFacade() => _buildingFacadeRepository.GetAllEntity();
        public ReturnEntity<BuildingFacade> GetBuildingFacadeById(int buildingFacade) => _buildingFacadeRepository.GetEntityById(buildingFacade);
        public async Task<Result> CreateBuildingFacade(BuildingFacade buildingFacade)
        {
            var entity = _buildingFacadeRepository.AddEntity(buildingFacade);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _buildingFacadeRepository.SaveChangeAsync();
        }
        public async Task<Result> DeleteBuildingFacadeById(int buildingFacadeId)
        {
            var entity = _buildingFacadeRepository.DeleteEntityById(buildingFacadeId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _buildingFacadeRepository.SaveChangeAsync();
        }

        public async Task<Result> EditBuildungFacade(BuildingFacade buildingFacade)
        {
            var entity = _buildingFacadeRepository.GetEntityById(buildingFacade.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = buildingFacade.Name;
            var updateEntity = _buildingFacadeRepository.AddEntity(buildingFacade);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _buildingFacadeRepository.SaveChangeAsync();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
