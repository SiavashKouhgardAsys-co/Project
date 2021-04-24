using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IBuyerService
    {
        ReturnEntity_List<BuyerViewmodel> GetAllBuyers(string userId);
        ReturnEntity<Buyer> GetBuyerById(int id, string userId);
        ReturnEntity<BuyerDetailsViewmodel> GetBuyerByIdForDetails(int id , string userId);
        ReturnEntity_IQueryable<BuyerTel> GetAllBuyerTels();
        ReturnEntity_IQueryable<BuyerTel> GetAllBuyerTelByUserId(int id);
        ReturnEntity<BuyerTel> GetBuyerTelById(int id);
        Task<Result> CreateBuyer(Buyer buyer);
        Task<Result> DeleteBuyer(int id);
        Task<Result> EditBuyer(Buyer buyer);
        Task<Result> CreateBuyerTel(BuyerTel buyerTel);
        Task<Result> DeleteBuyerTel(int id);
        Task<Result> EditBuyerTel(BuyerTel buyerTel);

    }
}
