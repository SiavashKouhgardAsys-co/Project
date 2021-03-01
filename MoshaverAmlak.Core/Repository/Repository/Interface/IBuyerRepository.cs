using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IBuyerRepository
    {
        ReturnEntity_IQueryable<Buyer> GetAllBuyers();
        ReturnEntity<Buyer> GetBuyerById(int id);
        Task<Result> CreateBuyer(Buyer buyer);
        Task<Result> DeleteBuyer(int buyerId);
        Task<Result> EditBuyer(Buyer buyer);
    }
}
