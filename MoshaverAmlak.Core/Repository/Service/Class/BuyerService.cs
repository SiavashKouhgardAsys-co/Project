using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _buyer;
        public BuyerService(IBuyerRepository buyer)
        {
            _buyer = buyer;
        }

        public ReturnEntity_IQueryable<Buyer> GetAllBuyers(string userId) => _buyer.GetAllBuyers(userId);
        public ReturnEntity<Buyer> GetBuyerById(int id , string userId) => _buyer.GetBuyerById(id , userId);

        public async Task<Result> CreateBuyer(Buyer buyer) => await _buyer.CreateBuyer(buyer);
        public async Task<Result> DeleteBuyer(int id) => await _buyer.DeleteBuyer(id);
        public async Task<Result> EditBuyer(Buyer buyer) => await _buyer.EditBuyer(buyer);
    }
}
