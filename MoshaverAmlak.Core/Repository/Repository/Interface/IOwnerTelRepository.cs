using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IOwnerTelRepository
    {
        public ReturnEntity<string> GetAllTels(int id);
        ReturnEntity_IQueryable<OwnerTel> GetAllOwnerTel();
        ReturnEntity_IQueryable<OwnerTel> GetAllOwnerTelByUserId(int id);
        ReturnEntity<OwnerTel> GetOwnerTelById(int ownerId);
        Task<Result> CreateOwnerTel(OwnerTel ownerTel);
        Task<Result> DeleteOwnerTel(int ownerId);
        Task<Result> EditOwnerTel(OwnerTel ownerTel);
    }
}
