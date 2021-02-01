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
    public class AirConditionerRepository : IAirConditionerRepository
    {
        private readonly IGenericRepository<AirConditioner> _airConditionerRepository;

        public AirConditionerRepository(IGenericRepository<AirConditioner> airConditionerRepository)
        {
            _airConditionerRepository = airConditionerRepository;
        }

        public ReturnEntity_IQueryable<AirConditioner> GetAllAirConditioner() => _airConditionerRepository.GetAllEntity();
        public ReturnEntity<AirConditioner> GetAirConditionerById(int airConditionerId) => _airConditionerRepository.GetEntityById(airConditionerId);
        public async Task<Result> CreateAirConditioner(AirConditioner airConditioner)
        {
            var entity = _airConditionerRepository.AddEntity(airConditioner);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _airConditionerRepository.SaveChangeAsync();
        }
        public async Task<Result> DeleteAirConditionerById(int airConditionerId)
        {
            var entity = _airConditionerRepository.DeleteEntityById(airConditionerId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _airConditionerRepository.SaveChangeAsync();
        }
        public async Task<Result> UpdateAirConditioner(AirConditioner airConditioner)
        {
            var entity = GetAirConditionerById(airConditioner.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = airConditioner.Name;
            var update_entity = _airConditionerRepository.UpdateEntity(entity.Entity);
            if (update_entity.StatusResult != (int)Result.Status.OK) return update_entity;
            return await _airConditionerRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _airConditionerRepository?.Dispose();
        }
    }
}
