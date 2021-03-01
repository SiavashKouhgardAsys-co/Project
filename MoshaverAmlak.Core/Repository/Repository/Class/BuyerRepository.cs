using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly IGenericRepository<Buyer> _buyerRepository;
        public BuyerRepository(IGenericRepository<Buyer> buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public ReturnEntity_IQueryable<Buyer> GetAllBuyers() => _buyerRepository.GetAllEntity();
        public ReturnEntity<Buyer> GetBuyerById(int id) => _buyerRepository.GetEntityById(id);
        public async Task<Result> CreateBuyer(Buyer buyer)
        {
            var entity = await _buyerRepository.AddEntity(buyer);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _buyerRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteBuyer(int buyerId)
        {
            var entity =  _buyerRepository.DeleteEntityById(buyerId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _buyerRepository.SaveChangeAsync();
        }

        public async Task<Result> EditBuyer(Buyer buyer)
        {
            var entity = _buyerRepository.GetEntityById(buyer.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.FullName = buyer.FullName;
            var updateEnttiy = _buyerRepository.UpdateEntity(entity.Entity);
            if (updateEnttiy.StatusResult != (int)Result.Status.OK) return updateEnttiy;
            return await _buyerRepository.SaveChangeAsync();
        }
        
    }
}
