using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IBuyerTelRepository
    {
        ReturnEntity_IQueryable<BuyerTel> GetAllBuyerTel();
        ReturnEntity<BuyerTel> GetBuyerTelById(int buyerId);
        ReturnEntity_IQueryable<BuyerTel> GetAllBuyerTelByUserId(int id);
        Task<Result> CreateBuyerTel(BuyerTel buyerTel);
        Task<Result> DeleteBuyerTel(int buyerId);
        Task<Result> EditBuyerTel(BuyerTel buyerTel);
        ReturnEntity<string> GetAllTels(int id);
    }
}
