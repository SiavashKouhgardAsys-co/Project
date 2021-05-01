using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class RealStateAddressRepository : IRealStateAddressRepository
    {
        public readonly IGenericRepository<RealEstateAddress> _realStateAddressRepository;
        public RealStateAddressRepository(IGenericRepository<RealEstateAddress> realStateAddressRepository)
        {
            _realStateAddressRepository = realStateAddressRepository;
        }

        public ReturnEntity<string> GetAllAddresses(int id)
        {
            ReturnEntity<string> returnEntity = new ReturnEntity<string>();
            var data = _realStateAddressRepository.GetAllEntityByOtherColumn(x => x.RealEstateId == id);
            returnEntity.Result = data.Result;

            if (data.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            string addresses = "";
            var addressList = data.Entity.ToList();
            for (int i = 0; i < addressList.Count(); i++)
            {
                addresses += addressList[i].Address;
                if (i < addressList.Count())
                {
                    addresses += " / ";
                }
            }

            returnEntity.Entity = addresses;
            return returnEntity;
        }

        public ReturnEntity_IQueryable<RealEstateAddress> GetAllRealStateAddress() => _realStateAddressRepository.GetAllEntity();

        public ReturnEntity_IQueryable<RealEstateAddress> GetAllRealStateTelByUserId(int id) => _realStateAddressRepository.GetAllEntityByOtherColumn(x => x.RealEstateId == id);

        public ReturnEntity<RealEstateAddress> GetRealStateAddressById(int realStateId) => _realStateAddressRepository.GetEntityByOtherColumn(x => x.RealEstateId == realStateId);

        public async Task<Result> CreateRealStateAddress(RealEstateAddress realEstateAddress)
        {
            var entity = await _realStateAddressRepository.AddEntity(realEstateAddress);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _realStateAddressRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteRealStateAddress(int realStateId)
        {
            var entity = _realStateAddressRepository.DeleteEntityById(realStateId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _realStateAddressRepository.SaveChangeAsync();
        }

        public async Task<Result> EditRealStateAddress(RealEstateAddress realEstateAddress)
        {
            var entity = _realStateAddressRepository.GetEntityById(realEstateAddress.RealEstateId);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            
            entity.Entity.Address = realEstateAddress.Address;

            var updateEntity = _realStateAddressRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _realStateAddressRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _realStateAddressRepository?.Dispose();
        }


    }
}
