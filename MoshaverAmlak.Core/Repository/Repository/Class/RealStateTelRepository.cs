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
    public class RealStateTelRepository : IRealStateTelRepository
    {
        public readonly IGenericRepository<RealEstateTel> _realStateTelRepository;
        public RealStateTelRepository(IGenericRepository<RealEstateTel> realStateTelRepository)
        {
            _realStateTelRepository = realStateTelRepository;
        }

        public ReturnEntity<string> GetAllTels(int id)
        {
            ReturnEntity<string> returnEntity = new ReturnEntity<string>();
            var data = _realStateTelRepository.GetAllEntityByOtherColumn(x => x.RealEstateId == id);
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

        public ReturnEntity_IQueryable<RealEstateTel> GetAllRealStateTel() => _realStateTelRepository.GetAllEntity();
        
        public ReturnEntity_IQueryable<RealEstateTel> GetAllRealStateTelByUserId(int id) => _realStateTelRepository.GetAllEntityByOtherColumn(x => x.RealEstateId == id);

        public ReturnEntity<RealEstateTel> GetRealStateTelById(int realStateId) => _realStateTelRepository.GetEntityByOtherColumn(x => x.RealEstateId == realStateId);

        public async Task<Result> CreateRealStateTel(RealEstateTel realEstateTel)
        {
            var entity = await _realStateTelRepository.AddEntity(realEstateTel);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _realStateTelRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteRealStateTel(int realStateId)
        {
            var entity = _realStateTelRepository.DeleteEntityById(realStateId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _realStateTelRepository.SaveChangeAsync();
        }

        public async Task<Result> EditRealStateTel(RealEstateTel realEstateTel)
        {
            var entity = _realStateTelRepository.GetEntityById(realEstateTel.RealEstateId);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Tel = realEstateTel.Tel;
            
            var updateEntity = _realStateTelRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _realStateTelRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _realStateTelRepository?.Dispose();
        }


    }
}
