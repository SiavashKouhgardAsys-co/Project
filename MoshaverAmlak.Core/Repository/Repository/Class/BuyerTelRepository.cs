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
    public class BuyerTelRepository : IBuyerTelRepository
    {
        public readonly IGenericRepository<BuyerTel> _buyerTelRepository;
        public BuyerTelRepository(IGenericRepository<BuyerTel> buyerTelRepository)
        {
            _buyerTelRepository = buyerTelRepository;
        }

        public ReturnEntity<string> GetAllTels(int id)
        {
            ReturnEntity<string> returnEntity = new ReturnEntity<string>();
            var data = _buyerTelRepository.GetAllEntity();
            returnEntity.Result = data.Result;

            if (data.Result.StatusResult != (int)Result.Status.OK) return returnEntity ;
            string tels = "";
            var telList = data.Entity.ToList();
            for (int i = 0; i < telList.Count(); i++)
            {
                tels += telList[i].Tel;
                if(i < telList.Count())
                {
                    tels += " - ";
                }
            }
            returnEntity.Entity = tels;
            return returnEntity;
        }

        public ReturnEntity_IQueryable<BuyerTel> GetAllBuyerTel() => _buyerTelRepository.GetAllEntity();
        public ReturnEntity_IQueryable<BuyerTel> GetAllBuyerTelByUserId(int id) => _buyerTelRepository.GetAllEntityByOtherColumn(x => x.BuyerId == id);
        public ReturnEntity<BuyerTel> GetBuyerTelById(int id) => _buyerTelRepository.GetEntityById(id);
        public async Task<Result> CreateBuyerTel(BuyerTel buyerTel)
        {
            var entity = await _buyerTelRepository.AddEntity(buyerTel);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _buyerTelRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteBuyerTel(int buyerId)
        {
            var entity = _buyerTelRepository.DeleteEntityById(buyerId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _buyerTelRepository.SaveChangeAsync();
        }

        public async Task<Result> EditBuyerTel(BuyerTel buyerTel)
        {
            var entity = _buyerTelRepository.GetEntityById(buyerTel.BuyerId);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Tel = buyerTel.Tel;
            var updateEntity = _buyerTelRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _buyerTelRepository.SaveChangeAsync();
        }
    }
}
