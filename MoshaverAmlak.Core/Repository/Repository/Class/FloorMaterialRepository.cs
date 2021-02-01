using Microsoft.EntityFrameworkCore.Update;
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
    class FloorMaterialRepository : IFloorMaterialRepository
    {
        private readonly IGenericRepository<FloorMaterial> _floorMaterialRepository;
        public ReturnEntity_IQueryable<FloorMaterial> GetAllFloorMaterial() => _floorMaterialRepository.GetAllEntity();
        public ReturnEntity<FloorMaterial> GetFloorMaterialById(int floorMaterialId) => _floorMaterialRepository.GetEntityById(floorMaterialId);
        public async Task<Result> CreateFloorMaterial(FloorMaterial floorMaterial)
        {
            var entity = _floorMaterialRepository.AddEntity(floorMaterial);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _floorMaterialRepository.SaveChangeAsync();

        }
        public async Task<Result> DeleteFloorMaterialById(int floorMaterialId)
        {
            var entity = _floorMaterialRepository.DeleteEntityById(floorMaterialId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _floorMaterialRepository.SaveChangeAsync();
        }
        public async Task<Result> EditFloorMaterial(FloorMaterial floorMaterial)
        {
            var entity = _floorMaterialRepository.GetEntityById(floorMaterial.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = floorMaterial.Name;
            var updateEntity = _floorMaterialRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _floorMaterialRepository.SaveChangeAsync();
        }
        public void Dispose()
        {
            _floorMaterialRepository?.Dispose();
        }
    }
}
