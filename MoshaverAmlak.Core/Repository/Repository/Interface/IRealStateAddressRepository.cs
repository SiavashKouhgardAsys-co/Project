using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IRealStateAddressRepository
    {
        ReturnEntity<string> GetAllAddresses(int id);
        ReturnEntity_IQueryable<RealEstateAddress> GetAllRealStateAddress();
        ReturnEntity_IQueryable<RealEstateAddress> GetAllRealStateTelByUserId(int id);
        ReturnEntity<RealEstateAddress> GetRealStateAddressById(int realStateId);
        Task<Result> CreateRealStateAddress(RealEstateAddress realEstateAddress);
        Task<Result> DeleteRealStateAddress(int realStateId);
        Task<Result> EditRealStateAddress(RealEstateAddress realEstateAddress);
        void Dispose();
    }
}
