using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class DoorOpenerTypeRepository : IDoorOpenerTypeRepository
    {
        private readonly IGenericRepository<DoorOpenerType> _doorOpenerTypeRepository;
        public DoorOpenerTypeRepository(IGenericRepository<DoorOpenerType> doorOpenerTypeRepository)
        {
            _doorOpenerTypeRepository = doorOpenerTypeRepository;
        }

        public ReturnEntity_IQueryable<DoorOpenerType> GetAllDoorOpenerType() => _doorOpenerTypeRepository.GetAllEntity();
        public ReturnEntity<DoorOpenerType> GetDoorOpenerTypeById(int doorOpenerTypeId) => _doorOpenerTypeRepository.GetEntityById(doorOpenerTypeId);
        public async Task<Result> CreateDoorOpenerType(DoorOpenerType doorOpenerType)
        {
            var entity = _doorOpenerTypeRepository.AddEntity(doorOpenerType);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _doorOpenerTypeRepository.SaveChangeAsync();
        }
        public async Task<Result> UpdateDoorOpenerType(DoorOpenerType doorOpenerType)
        {
            var entity = GetDoorOpenerTypeById(doorOpenerType.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = doorOpenerType.Name;
            var update_entity = _doorOpenerTypeRepository.UpdateEntity(entity.Entity);
            if (update_entity.StatusResult != (int)Result.Status.OK) return update_entity;
            return await _doorOpenerTypeRepository.SaveChangeAsync();
        }
        public async Task<Result> DeleteDoorOpenerTypeById(int doorOpenerTypeId)
        {
            var entity = _doorOpenerTypeRepository.DeleteEntityById(doorOpenerTypeId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _doorOpenerTypeRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _doorOpenerTypeRepository?.SaveChangeAsync();
        }
    }
}
