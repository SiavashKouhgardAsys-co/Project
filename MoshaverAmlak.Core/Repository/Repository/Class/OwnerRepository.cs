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

        public async Task<Result> DeleteOwner(int ownerId)
        {
            var entity = _ownerRepository.DeleteEntityById(ownerId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _ownerRepository.SaveChangeAsync();
        }
        
        public async Task<Result> EditOwner(Owner owner)
        {
            var entity = _ownerRepository.GetEntityById(owner.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.FullName = owner.FullName;
            entity.Entity.Descrption = owner.Descrption;
            var updateEntity = _ownerRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _ownerRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _ownerRepository?.Dispose();
        }
    }
}
