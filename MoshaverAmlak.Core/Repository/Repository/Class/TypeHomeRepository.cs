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
    class TypeHomeRepository : ITypeHomeRepository
    {
        private readonly IGenericRepository<TypeHome> _typeHomeRespository;
        public ReturnEntity_IQueryable<TypeHome> GetAllTypeHome() => _typeHomeRespository.GetAllEntity();
        public ReturnEntity<TypeHome> GetTypeHomeById(int typeHomeId) 
            => _typeHomeRespository.GetEntityById(typeHomeId);
        public async Task<Result> CreateTypeHome(TypeHome typeHome)
        {
            var entity = _typeHomeRespository.AddEntity(typeHome);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _typeHomeRespository.SaveChangeAsync();
        }

        public async Task<Result> DeleteTypeHomeById(int typeHomeId)
        {
            var entity = _typeHomeRespository.DeleteEntityById(typeHomeId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _typeHomeRespository.SaveChangeAsync();
        }

        public async Task<Result> EditTypeHome(TypeHome typeHome)
        {
            var entity = _typeHomeRespository.GetEntityById(typeHome.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = typeHome.Name;
            var updateEntity = _typeHomeRespository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _typeHomeRespository.SaveChangeAsync();
        }
        public void Dispose()
        {
            _typeHomeRespository?.Dispose();
        }
    }
}
