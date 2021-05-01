using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IRealStateService
    {
        ReturnEntity<RealEstate> GetRealStateById(int id, string userId);
        ReturnEntity_IQueryable<RealEstateTel> GetAllRealStateTels();
        ReturnEntity_IQueryable<RealEstateAddress> GetAllRealStateAddresses();
        ReturnEntity_IQueryable<RealEstateTel> GetAllRealStateTelByUserId(int id);
        ReturnEntity_IQueryable<RealEstateAddress> GetAllRealStateAddressByUserId(int id);
        ReturnEntity<RealEstateTel> GetRealStateTelById(int id);
        ReturnEntity<RealEstateAddress> GetRealStateAddressById(int id);
        ReturnEntity<RealStateDetailsViewmodel> GetRealStateForDetails(int id, string userId);
        ReturnEntity_List<RealStateViewmodel> GetAllRealStates(string userId);
        Task<Result> CreateRealState(RealEstate realEstate);
        Task<Result> CreateRealStateTel(RealEstateTel realEstateTel);
        Task<Result> CreateRealStateAddress(RealEstateAddress realEstateAddress);
        Task<Result> DeleteRealState(int id);
        Task<Result> DeleteRealStateTel(int id);
        Task<Result> DeleteRealStateAddress(int id);
        Task<Result> EditRealState(RealEstate realEstate);
        Task<Result> EditRealEStateAddress(RealEstateAddress realEstateAddress);
    }
}
