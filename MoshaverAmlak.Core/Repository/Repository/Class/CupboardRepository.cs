using Microsoft.EntityFrameworkCore.Update.Internal;
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
    class CupboardRepository : ICupboardRepository
    {
        private readonly IGenericRepository<Cupboard> _cupboardRepository;

        public ReturnEntity_IQueryable<Cupboard> GetAllCupboard()
            => _cupboardRepository.GetAllEntity();

        public ReturnEntity<Cupboard> GetCupboardById(int cubBoardId)
            => _cupboardRepository.GetEntityById(cubBoardId);

        public async Task<Result> CreateCupboard(Cupboard cupboard)
        {
            var entity = _cupboardRepository.AddEntity(cupboard);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _cupboardRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteCupboardById(int cupboardId)
        {
            var entity = _cupboardRepository.DeleteEntityById(cupboardId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _cupboardRepository.SaveChangeAsync();
        }

        public async Task<Result> EditCupboard(Cupboard cupboard)
        {
            var entity = GetCupboardById(cupboard.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = cupboard.Name;
            var updateEntity = _cupboardRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _cupboardRepository.SaveChangeAsync();
        }
        public void Dispose()
        {
            _cupboardRepository?.Dispose();
        }
    }
}
