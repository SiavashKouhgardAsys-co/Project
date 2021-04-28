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

        public ReturnEntity_List<OwnerViewmodel> GetAllOwners(string userId)
        {
            ReturnEntity_List<OwnerViewmodel> returnEntity = new ReturnEntity_List<OwnerViewmodel>();
            var data = _owner.GetAllOwners(userId);
            returnEntity.Result = data.Result;
            if (data.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            List<OwnerViewmodel> ownerViewmodels = new List<OwnerViewmodel>();
            foreach (var item in data.Entity)
            {
                Owner owner = new Owner()
                {
                    Id = item.Id
                };
                var telInfo = _ownerTel.GetOwnerTelById(owner.Id);
                returnEntity.Result = telInfo.Result;
                if (telInfo.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
                string tempTel = "";
                
                if (telInfo.Entity == null)
                    tempTel = " - ";
                else
                    tempTel = telInfo.Entity.Tel;
                
                ownerViewmodels.Add(new OwnerViewmodel()
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Description = item.Descrption,    
                    Tel = tempTel,
                });
            }
            returnEntity.Entity = ownerViewmodels;
            return returnEntity;
        }
        public ReturnEntity_IQueryable<OwnerTel> GetAllOwnerTels() => _ownerTel.GetAllOwnerTel();
        public ReturnEntity<Owner> GetOwnerById(int id , string userId) => _owner.GetOwnerById(id , userId);
        public ReturnEntity<OwnerTel> GetOwnerTelById(int id) => _ownerTel.GetOwnerTelById(id);
        public ReturnEntity<OwnerDetailsViewmodel> GetOwnerByIdForDetails(int id , string userId)
        {
            ReturnEntity<OwnerDetailsViewmodel> returnEntity = new ReturnEntity<OwnerDetailsViewmodel>();
            var dataOwnerTel = _ownerTel.GetAllOwnerTelByUserId(id);
            if (dataOwnerTel.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            var dataOwner = _owner.GetOwnerById(id, userId);
            if (dataOwner.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            returnEntity.Entity = new OwnerDetailsViewmodel()
            {
                Tels = dataOwnerTel.Entity,
                FullName = dataOwner.Entity.FullName,
                Description = dataOwner.Entity.Descrption
            };
            return returnEntity;
        }
        public ReturnEntity_IQueryable<OwnerTel> GetAllOwnerTelByUserId(int id) => _ownerTel.GetAllOwnerTelByUserId(id);

        public async Task<Result> CreateOwner(Owner owner) => await _owner.CreateOwner(owner);
        public async Task<Result> CreateOwnerTel(OwnerTel ownerTel) => await _ownerTel.CreateOwnerTel(ownerTel);
        public async Task<Result> DeleteOwner(int ownerId) => await _owner.DeleteOwner(ownerId);
        public async Task<Result> DeleteOwnerTel(int id) => await _ownerTel.DeleteOwnerTel(id);
        public async Task<Result> EditOwner(Owner owner) => await _owner.EditOwner(owner);
        public async Task<Result> EditOwnerTel(OwnerTel ownerTel) => await _ownerTel.EditOwnerTel(ownerTel);

    }
}
