using Microsoft.VisualBasic;
using MoshaverAmlak.Core.Repository.Repository.Interface;
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
    class NeighbourhoodRepositroy : INeighbourhoodRepository
    {
        private readonly IGenericRepository<Neighbourhood> _neighbourhoodRepository;
        public NeighbourhoodRepositroy(IGenericRepository<Neighbourhood> neighbourhoodRepository)
        {
            _neighbourhoodRepository = neighbourhoodRepository;
        }

        public ReturnEntity_IQueryable<Neighbourhood> GetAllNeighbourhood() => _neighbourhoodRepository.GetAllEntity();
        public ReturnEntity<Neighbourhood> GetNeighbourhoodById(int neighbourhoodId)
            => _neighbourhoodRepository.GetEntityById(neighbourhoodId);

        public async Task<Result> CreateNeighbourhood(Neighbourhood neighbourhood)
        {
            var entity = _neighbourhoodRepository.AddEntity(neighbourhood);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _neighbourhoodRepository.SaveChangeAsync();
        }
        public async Task<Result> DeleteNeighbourhoodById(int neighbourhoodId)
        {
            var entity = _neighbourhoodRepository.DeleteEntityById(neighbourhoodId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _neighbourhoodRepository.SaveChangeAsync();
        }

        public async Task<Result> EditNeighbourhood(Neighbourhood neighbourhood)
        {
            var entity = GetNeighbourhoodById(neighbourhood.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = neighbourhood.Name;
            var updateEntity = _neighbourhoodRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _neighbourhoodRepository.SaveChangeAsync();
        } 

        public void Dispose()
        {
            _neighbourhoodRepository?.Dispose();
        }

    }
}
