using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class RealStateService : IRealStateService
    {
        private readonly IRealStateRepository _realState;
        private readonly IRealStateTelRepository _realStateTel;
        private readonly IRealStateAddressRepository _realStateAddress;
        public RealStateService(IRealStateRepository realState , IRealStateTelRepository realStateTel , IRealStateAddressRepository realStateAddress)
        {
            _realState = realState;
            _realStateTel = realStateTel;
            _realStateAddress = realStateAddress;
        }


        //Get RealState
        public ReturnEntity<RealEstate> GetRealStateById(int id, string userId) => _realState.GetRealStateById(id, userId);
        public ReturnEntity_IQueryable<RealEstateTel> GetAllRealStateTels() => _realStateTel.GetAllRealStateTel();
        public ReturnEntity_IQueryable<RealEstateAddress> GetAllRealStateAddresses() => _realStateAddress.GetAllRealStateAddress();
        public ReturnEntity_IQueryable<RealEstateTel> GetAllRealStateTelByUserId(int id) => _realStateTel.GetAllRealStateTelByUserId(id);
        public ReturnEntity_IQueryable<RealEstateAddress> GetAllRealStateAddressByUserId(int id) => _realStateAddress.GetAllRealStateTelByUserId(id);
        public ReturnEntity<RealEstateTel> GetRealStateTelById(int id) => _realStateTel.GetRealStateTelById(id);
        public ReturnEntity<RealEstateAddress> GetRealStateAddressById(int id) => _realStateAddress.GetRealStateAddressById(id);
        public ReturnEntity<RealStateDetailsViewmodel> GetRealStateForDetails(int id, string userId)
        {
            ReturnEntity<RealStateDetailsViewmodel> returnEntity = new ReturnEntity<RealStateDetailsViewmodel>();

            var dataRealState = _realState.GetRealStateById(id, userId);
            if (dataRealState.Result.StatusResult != (int)Result.Status.OK) return returnEntity;

            var dataRealStateTel = _realStateTel.GetAllRealStateTelByUserId(id);
            if (dataRealStateTel.Result.StatusResult != (int)Result.Status.OK) return returnEntity;

            var dataRealStateAddress = _realStateAddress.GetAllRealStateTelByUserId(id);
            if (dataRealStateAddress.Result.StatusResult != (int)Result.Status.OK) return returnEntity;

            returnEntity.Entity = new RealStateDetailsViewmodel()
            {
                Name = dataRealState.Entity.Name,
                Description = dataRealState.Entity.Description,
                RegistrationNumber = dataRealState.Entity.RegistrationNumber,
                RealEstateTels = dataRealStateTel.Entity,
                RealEstateAddresses = dataRealStateAddress.Entity
            };

            return returnEntity;
        }
        public ReturnEntity_List<RealStateViewmodel> GetAllRealStates(string userId)
        {
            ReturnEntity_List<RealStateViewmodel> returnEntity = new ReturnEntity_List<RealStateViewmodel>();
            
            var data = _realState.GetAllRealStates(userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return returnEntity;

            returnEntity.Result = data.Result;

            List<RealStateViewmodel> realStateViewmodels = new List<RealStateViewmodel>();

            foreach (var item in data.Entity)
            {
                RealEstate realEstate = new RealEstate()
                {
                    Id = item.Id
                };
                var telInfo = _realStateTel.GetRealStateTelById(realEstate.Id);
                if (telInfo.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
                
                returnEntity.Result = telInfo.Result;

                string tempTel = "";
                if (telInfo.Entity == null)
                    tempTel = " - ";
                else
                    tempTel = telInfo.Entity.Tel;

                var addressInfo = _realStateAddress.GetRealStateAddressById(realEstate.Id);
                if (addressInfo.Result.StatusResult != (int)Result.Status.OK) return returnEntity;

                returnEntity.Result = addressInfo.Result;

                string tempAddress = "";
                if (addressInfo.Entity == null)
                    tempAddress = " - ";
                else
                    tempAddress = addressInfo.Entity.Address;

                realStateViewmodels.Add(new RealStateViewmodel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Tel = tempTel,
                    Address = tempAddress,
                    RegistrationNumber = item.RegistrationNumber

                });
            }

            returnEntity.Entity = realStateViewmodels;
            return returnEntity;

        }

        //Create RealState
        public async Task<Result> CreateRealState(RealEstate realEstate) => await _realState.CreateRealState(realEstate);
        public async Task<Result> CreateRealStateTel(RealEstateTel realEstateTel) => await _realStateTel.CreateRealStateTel(realEstateTel);
        public async Task<Result> CreateRealStateAddress(RealEstateAddress realEstateAddress) => await _realStateAddress.CreateRealStateAddress(realEstateAddress);

        //Delete RealState 
        public async Task<Result> DeleteRealState(int id) => await _realState.DeleteRealState(id);
        public async Task<Result> DeleteRealStateTel(int id) => await _realStateTel.DeleteRealStateTel(id);
        public async Task<Result> DeleteRealStateAddress(int id) => await _realStateAddress.DeleteRealStateAddress(id);

        //Edit RealState
        public async Task<Result> EditRealState(RealEstate realEstate) => await _realState.EditRealState(realEstate);
        public async Task<Result> EditRealEStateAddress(RealEstateAddress realEstateAddress) => await _realStateAddress.EditRealStateAddress(realEstateAddress);
               
        


    }
}
