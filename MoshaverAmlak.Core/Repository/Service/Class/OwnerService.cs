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
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _owner;
        private readonly IOwnerTelRepository _ownerTel;
        public OwnerService(IOwnerRepository owner, IOwnerTelRepository ownerTel)
        {
            _owner = owner;
            _ownerTel = ownerTel;
        }

        public ReturnEntity_List<OwnerViewmodel> GetAllOwners(string ownerId)
        {
            ReturnEntity_List<OwnerViewmodel> returnEntity = new ReturnEntity_List<OwnerViewmodel>();
            var data = _owner.GetAllOwners(ownerId);
            returnEntity.Result = data.Result;
            if (data.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            List<OwnerViewmodel> ownerViewmodels = new List<OwnerViewmodel>();
            foreach (var item in data.Entity)
            {
                var telInfo = _ownerTel.GetAllTels(item.Id);
                returnEntity.Result = telInfo.Result;
                ownerViewmodels.Add(new OwnerViewmodel()
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Tel = telInfo.Entity
                });
            }
            returnEntity.Entity = ownerViewmodels;
            return returnEntity;
        }
        public ReturnEntity_IQueryable<OwnerTel> GetAllOwnerTels() => _ownerTel.GetAllOwnerTel();
        public ReturnEntity<Owner> GetOwnerById(int id , string userId) => _owner.GetOwnerById(id , userId);
        public ReturnEntity<OwnerTel> GetOwnerTelById(int id) => _ownerTel.GetOwnerTelById(id);
        public ReturnEntity_IQueryable<OwnerTel> GetAllOwnerTelByUserId(int id) => _ownerTel.GetAllOwnerTelByUserId(id);

        public async Task<Result> CreateOwner(Owner owner) => await _owner.CreateOwner(owner);
        public async Task<Result> CreateOwnerTel(OwnerTel ownerTel) => await _ownerTel.CreateOwnerTel(ownerTel);
        public async Task<Result> DeleteOwner(int ownerId) => await _owner.DeleteOwner(ownerId);
        public async Task<Result> DeleteOwnerTel(int id) => await _owner.DeleteOwner(id);
        public async Task<Result> EditOwner(Owner owner) => await _owner.EditOwner(owner);
        public async Task<Result> EditOwnerTel(OwnerTel ownerTel) => await _ownerTel.EditOwnerTel(ownerTel);

    }
}
