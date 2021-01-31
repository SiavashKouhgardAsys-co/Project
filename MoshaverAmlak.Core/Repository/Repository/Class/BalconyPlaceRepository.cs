using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    class BalconyPlaceRepository : IBalconyPlaceRepository
    {
        private readonly IGenericRepository<BalconyPlace> _balconyPlaceRepository;
        public BalconyPlaceRepository(IGenericRepository<BalconyPlace> balconyPlaceRepository)
        {
            _balconyPlaceRepository = balconyPlaceRepository;
        }

        public ReturnEntity_IQueryable<BalconyPlace> GetAllBalconyPlace() => _balconyPlaceRepository.GetAllEntity();
        public ReturnEntity<BalconyPlace> GetBalconyPlaceById(int balconyPlaceId)
            => _balconyPlaceRepository.GetEntityById(balconyPlaceId);

        public async Task<Result> CreateBalconyPlace(BalconyPlace balconyPlace)
        {
            var entity = _balconyPlaceRepository.AddEntity(balconyPlace);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _balconyPlaceRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteBalconyPlaceById(int balconyPlaceId)
        {
            var entity = _balconyPlaceRepository.DeleteEntityById(balconyPlaceId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _balconyPlaceRepository.SaveChangeAsync();
        } 
        public async Task<Result> EditBalconyPlace(BalconyPlace balconyPlace)
        {
            var entity = GetBalconyPlaceById(balconyPlace.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = balconyPlace.Name;
            var updateEntity = _balconyPlaceRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _balconyPlaceRepository.SaveChangeAsync();

        }

        public void Dispose()
        {
            _balconyPlaceRepository?.Dispose();
        }

    }
}
