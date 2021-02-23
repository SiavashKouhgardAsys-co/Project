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
    public class HomeFileTypeRepository : IHomeFileTypeRepository
    {
        private readonly IGenericRepository<HomeFileType> _homeFileTypeRepository;

        public HomeFileTypeRepository(IGenericRepository<HomeFileType> homeFileTypeRepository)
        {
            _homeFileTypeRepository = homeFileTypeRepository;
        }

        public ReturnEntity_IQueryable<HomeFileType> GetAllHomeFileType() =>
            _homeFileTypeRepository.GetAllEntity();
        public ReturnEntity<HomeFileType> GetHomeFileTypeById(int homeFileTypeId) => 
            _homeFileTypeRepository.GetEntityById(homeFileTypeId);
        
        public async Task<Result> CreateHomeFileType(HomeFileType homeFileType)
        {
            var entity = _homeFileTypeRepository.AddEntity(homeFileType);
            if (entity.Status != (int)Result.Status.OK) return await entity;
            return await _homeFileTypeRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteHomeFileTypeById(int homeFileTypeId)
        {
            var entity = _homeFileTypeRepository.DeleteEntityById(homeFileTypeId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _homeFileTypeRepository.SaveChangeAsync();
        }
        public async Task<Result> EditHomeFileType(HomeFileType homeFileType)
        {
            var entity = _homeFileTypeRepository.GetEntityById(homeFileType.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = homeFileType.Name;
            var updateEntity = _homeFileTypeRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _homeFileTypeRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _homeFileTypeRepository.Dispose();
        }
       
    }
}
