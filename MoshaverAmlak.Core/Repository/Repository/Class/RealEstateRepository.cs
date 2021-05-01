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
    public class RealEstateRepository : IRealStateRepository
    {
        private readonly IGenericRepository<RealEstate> _realStateRepository;
        public RealEstateRepository(IGenericRepository<RealEstate> realStateRepository)
        {
            _realStateRepository = realStateRepository;
        }

        public ReturnEntity_IQueryable<RealEstate> GetAllRealStates(string userId) => _realStateRepository.GetAllEntityByOtherColumn(x => x.UserId == userId);

        public ReturnEntity<RealEstate> GetRealStateById(int id, string userId) => _realStateRepository.GetEntityByOtherColumn(x => x.UserId == userId && x.Id == id);

        public async Task<Result> CreateRealState(RealEstate realEstate)
        {
            var entity = await _realStateRepository.AddEntity(realEstate);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _realStateRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteRealState(int realStateId)
        {
            var entity = _realStateRepository.DeleteEntityById(realStateId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _realStateRepository.SaveChangeAsync();    
        }

        public async Task<Result> EditRealState(RealEstate realEstate)
        {
            var entity = _realStateRepository.GetEntityById(realEstate.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = realEstate.Name;
            entity.Entity.RealEstateAddresses = realEstate.RealEstateAddresses;
            entity.Entity.RegistrationNumber = realEstate.RegistrationNumber;
            entity.Entity.Description = realEstate.Description;
           
            var updateEnttiy = _realStateRepository.UpdateEntity(entity.Entity);
            if (updateEnttiy.StatusResult != (int)Result.Status.OK) return updateEnttiy;
            return await _realStateRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _realStateRepository?.Dispose();
        }

    }
}
