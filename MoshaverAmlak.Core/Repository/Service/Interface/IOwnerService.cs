using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IOwnerService
    {
        public ReturnEntity_List<OwnerViewmodel> GetAllOwners(string ownerId);
        public ReturnEntity_IQueryable<OwnerTel> GetAllOwnerTels();
        public ReturnEntity<Owner> GetOwnerById(int id, string userId);
        public ReturnEntity<OwnerTel> GetOwnerTelById(int id);
        ReturnEntity_IQueryable<OwnerTel> GetAllOwnerTelByUserId(int id);

        Task<Result> CreateOwner(Owner owner);
        Task<Result> CreateOwnerTel(OwnerTel ownerTel);
        Task<Result> DeleteOwner(int ownerId);
        Task<Result> DeleteOwnerTel(int id);
        Task<Result> EditOwner(Owner owner);
        Task<Result> EditOwnerTel(OwnerTel ownerTel);



    }
}
