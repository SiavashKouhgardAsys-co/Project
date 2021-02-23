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
    public class HomeDirectionRepository : IHomeDirectionRepository
    {
        private readonly IGenericRepository<HomeDirection> _homeDirectionRepository;

        public HomeDirectionRepository(IGenericRepository<HomeDirection> homeDirectionRepository)
        {
            _homeDirectionRepository = homeDirectionRepository;
        }

        public ReturnEntity_IQueryable<HomeDirection> GetAllHomeDirection()
            => _homeDirectionRepository.GetAllEntity();
        public ReturnEntity<HomeDirection> GetHomeDirectionById(int homeDirectionId)
            => _homeDirectionRepository.GetEntityById(homeDirectionId);
        public async Task<Result> CreateHomeDirection(HomeDirection homeDirection)
        {
            var entity = _homeDirectionRepository.AddEntity(homeDirection);
            if (entity.Status != (int)Result.Status.OK) return await entity;
            return await _homeDirectionRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteHomeDirectionById(int homeDirectionId)
        {
            var entity = _homeDirectionRepository.DeleteEntityById(homeDirectionId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _homeDirectionRepository.SaveChangeAsync();
        }

        public async Task<Result> EditHomeDirection(HomeDirection homeDirection)
        {
            var entity = _homeDirectionRepository.GetEntityById(homeDirection.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = homeDirection.Name;
            var updateEntity = _homeDirectionRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _homeDirectionRepository.SaveChangeAsync();
        }
        public void Dispose()
        {
            _homeDirectionRepository?.Dispose();
        }
    }
}
