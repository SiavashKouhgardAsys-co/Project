using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IRealStateRepository
    {
        ReturnEntity_IQueryable<RealEstate> GetAllRealStates(string userId);
        ReturnEntity<RealEstate> GetRealStateById(int id, string userId);
        Task<Result> CreateRealState(RealEstate realEstate);
        Task<Result> DeleteRealState(int realStateId);
        Task<Result> EditRealState(RealEstate realEstate);
        void Dispose();

    }
}
