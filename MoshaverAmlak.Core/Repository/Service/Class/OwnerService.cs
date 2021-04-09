using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerService;
        public OwnerService(IOwnerRepository ownerService)
        {
            _ownerService = ownerService;
        }

        public ReturnEntity_IQueryable<Owner> GetAllOwners(string userId) => _ownerService.GetAllOwners(userId);
        public ReturnEntity<Owner> GetOwnerById(int id , string userId) => _ownerService.GetOwnerById(id , userId);

        public async Task<Result> CreateOwner(Owner owner) => await _ownerService.CreateOwner(owner);
        public async Task<Result> DeleteOwner(int ownerId) => await _ownerService.DeleteOwner(ownerId);
        public async Task<Result> EditOwner(Owner owner) => await _ownerService.EditOwner(owner); 
    }
}
