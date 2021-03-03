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

        public ReturnEntity_IQueryable<Owner> GetAllOwners() => _ownerService.GetAllOwners();
        public ReturnEntity<Owner> GetOwnerById(int id) => _ownerService.GetOwnerById(id);

        public async Task<Result> CreateOwner(Owner owner) => await _ownerService.CreateOwner(owner);
    }
}
