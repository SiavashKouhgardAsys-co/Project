using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class OwnerTelRepository : IOwnerTelRepository
    {
        public readonly IGenericRepository<OwnerTel> _ownerTelRepository;
        public OwnerTelRepository(IGenericRepository<OwnerTel> ownerTelRepository)
        {
            _ownerTelRepository = ownerTelRepository;
        }

        public ReturnEntity<string> GetAllTels(int id)
        {
            ReturnEntity<string> returnEntity = new ReturnEntity<string>();
            var data = _ownerTelRepository.GetAllEntity();
            returnEntity.Result = data.Result;

            if (data.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            string tels = "";
            var telList = data.Entity.ToList();
            for (int i = 0; i < telList.Count(); i++)
            {
                tels += telList[i].Tel;
                if (i < telList.Count())
                {
                    tels += " - ";
                }
            }
            returnEntity.Entity = tels;
            return returnEntity;
        }

        public ReturnEntity_IQueryable<OwnerTel> GetAllOwnerTel() => _ownerTelRepository.GetAllEntity();
        public ReturnEntity_IQueryable<OwnerTel> GetAllOwnerTelByUserId(int id) => _ownerTelRepository.GetAllEntityByOtherColumn(x => x.OwnerId == id);
        public ReturnEntity<OwnerTel> GetOwnerTelById(int id) => _ownerTelRepository.GetEntityById(id);
        public async Task<Result> CreateOwnerTel(OwnerTel ownerTel)
        {
            var entity = await _ownerTelRepository.AddEntity(ownerTel);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _ownerTelRepository.SaveChangeAsync();
        }
        public async Task<Result> DeleteOwnerTel(int ownerId)
        {
            var entity = _ownerTelRepository.DeleteEntityById(ownerId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _ownerTelRepository.SaveChangeAsync();
        }
        public async Task<Result> EditOwnerTel(OwnerTel ownerTel)
        {
            var entity = _ownerTelRepository.GetEntityById(ownerTel.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Tel = ownerTel.Tel;
            var updateEntity = _ownerTelRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _ownerTelRepository.SaveChangeAsync();
        }

    }
}

