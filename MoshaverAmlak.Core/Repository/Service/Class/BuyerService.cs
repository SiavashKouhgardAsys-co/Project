using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Text;
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

        public ReturnEntity_IQueryable<Buyer> GetAllBuyers() => _buyer.GetAllBuyers();
        public ReturnEntity<Buyer> GetBuyerById(int id) => _buyer.GetBuyerById(id);

        public async Task<Result> CreateBuyer(Buyer buyer) => await _buyer.CreateBuyer(buyer);
        public async Task<Result> DeleteBuyer(int id) => await _buyer.DeleteBuyer(id);
        public async Task<Result> EditBuyer(Buyer buyer) => await _buyer.EditBuyer(buyer);
    }
}
