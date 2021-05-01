using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IRealStateTelRepository
    {
        ReturnEntity<string> GetAllTels(int id);
        ReturnEntity_IQueryable<RealEstateTel> GetAllRealStateTel();
        ReturnEntity_IQueryable<RealEstateTel> GetAllRealStateTelByUserId(int id);
        ReturnEntity<RealEstateTel> GetRealStateTelById(int buyerId);
        Task<Result> CreateRealStateTel(RealEstateTel realEstateTel);
        Task<Result> DeleteRealStateTel(int realStateId);
        Task<Result> EditRealStateTel(RealEstateTel realEstateTel);
        void Dispose();
    }
}
