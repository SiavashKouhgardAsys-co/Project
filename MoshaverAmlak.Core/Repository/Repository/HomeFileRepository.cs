using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository
{
    public class HomeFileRepository : IHomeFileRepository
    {
        private readonly IGenericRepository<HomeFile> _homeFileRepository;
        public HomeFileRepository(IGenericRepository<HomeFile> homeFileRepository)
        {
            _homeFileRepository = homeFileRepository;
        }

        public ReturnEntity_IQueryable<HomeFile> GetAllHomeFile() => _homeFileRepository.GetAllEntity();
        public ReturnEntity<HomeFile> GetHomeFileById(int id) => _homeFileRepository.GetEntityById(id);

        public async Task<Result> CreateHomeFile(HomeFile homeFile)
        {
            var entity = await _homeFileRepository.AddEntity(homeFile);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _homeFileRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteHomeFile(int homeFileId)
        {
            var entity = _homeFileRepository.DeleteEntityById(homeFileId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _homeFileRepository.SaveChangeAsync();
        }

        public async Task<Result> EditHomeFile(HomeFile homeFile)
        {
            var entity = _homeFileRepository.GetEntityById(homeFile.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;

            entity.Entity.Address = homeFile.Address;
            entity.Entity.OwnerName = homeFile.OwnerName;

            var updateEntity = _homeFileRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;

            return await _homeFileRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _homeFileRepository?.Dispose();
        }
    }
}
