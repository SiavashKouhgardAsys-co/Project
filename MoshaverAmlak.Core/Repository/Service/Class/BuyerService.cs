using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _buyer;
        private readonly IBuyerTelRepository _buyerTel;
        public BuyerService(IBuyerRepository buyer, IBuyerTelRepository buyerTel)
        {
            _buyer = buyer;
            _buyerTel = buyerTel;
        }

        public ReturnEntity_List<BuyerViewmodel> GetAllBuyers(string userId)
        {
            ReturnEntity_List<BuyerViewmodel> returnEntity = new ReturnEntity_List<BuyerViewmodel>();
            var data = _buyer.GetAllBuyers(userId);
            returnEntity.Result = data.Result;
            if (data.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            List<BuyerViewmodel> buyerViewmodels = new List<BuyerViewmodel>();
            foreach (var item in data.Entity)
            {
                Buyer buyer = new Buyer()
                {
                    Id = item.Id
                };
                var telInfo = _buyerTel.GetBuyerTelById(buyer.Id);
                returnEntity.Result = telInfo.Result;

                string tempTel = "";
                if (telInfo.Entity == null)
                    tempTel = " - ";
                else
                    tempTel = telInfo.Entity.Tel;
                
                if (telInfo.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
                buyerViewmodels.Add(new BuyerViewmodel()
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    FromInvestment = item.InvestimentFrom,
                    ToInvestment = item.InvestimentTo,
                    Tel = tempTel
                });
            }
            returnEntity.Entity = buyerViewmodels;
            return returnEntity;
        }

        public ReturnEntity_IQueryable<BuyerTel> GetAllBuyerTels() => _buyerTel.GetAllBuyerTel();
        public ReturnEntity<Buyer> GetBuyerById(int id, string userId) => _buyer.GetBuyerById(id, userId); 
        public ReturnEntity<BuyerDetailsViewmodel> GetBuyerByIdForDetails(int id, string userId)
        {
            ReturnEntity<BuyerDetailsViewmodel> returnEntity = new ReturnEntity<BuyerDetailsViewmodel>();
            var dataBuyerTel = _buyerTel.GetAllBuyerTelByUserId(id);
            if (dataBuyerTel.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            var dataBuyer = _buyer.GetBuyerById(id, userId);
            if (dataBuyer.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            returnEntity.Entity = new BuyerDetailsViewmodel()
            {
                Tels = dataBuyerTel.Entity,
                Description = dataBuyer.Entity.Description,
                FromInvestment = dataBuyer.Entity.InvestimentFrom,
                ToInvestment = dataBuyer.Entity.InvestimentTo,
                FullName = dataBuyer.Entity.FullName
            };
            return returnEntity;
        }
        public ReturnEntity<BuyerTel> GetBuyerTelById(int id) => _buyerTel.GetBuyerTelById(id);
        public ReturnEntity_IQueryable<BuyerTel> GetAllBuyerTelByUserId(int id) => _buyerTel.GetAllBuyerTelByUserId(id);

        public async Task<Result> CreateBuyer(Buyer buyer) => await _buyer.CreateBuyer(buyer);
        public async Task<Result> CreateBuyerTel(BuyerTel buyerTel) => await _buyerTel.CreateBuyerTel(buyerTel);
        public async Task<Result> DeleteBuyer(int id) => await _buyer.DeleteBuyer(id);
        public async Task<Result> DeleteBuyerTel(int id) => await _buyerTel.DeleteBuyerTel(id);
        public async Task<Result> EditBuyer(Buyer buyer) => await _buyer.EditBuyer(buyer);
        public async Task<Result> EditBuyerTel(BuyerTel buyerTel) => await _buyerTel.EditBuyerTel(buyerTel);

    }
}
