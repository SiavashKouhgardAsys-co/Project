using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class OwnerRepository : IOwnerRepository
    {
        public readonly IGenericRepository<Owner> _ownerRepository;
        public OwnerRepository(IGenericRepository<Owner> ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public ReturnEntity_IQueryable<Owner> GetAllOwners(string userId) => _ownerRepository.GetAllEntityByOtherColumn(x=>x.UserId == userId);
        public ReturnEntity<Owner> GetOwnerById(int id, string userId) => _ownerRepository.GetEntityByOtherColumn(x => x.UserId == userId && x.Id == id);
        
        public async Task<Result> CreateOwner(Owner owner)
        {
            var entity = await _ownerRepository.AddEntity(owner);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _ownerRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _ownerRepository?.Dispose();
        }
    }
}
