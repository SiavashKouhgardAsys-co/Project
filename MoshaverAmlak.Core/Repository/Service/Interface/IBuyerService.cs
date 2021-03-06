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
        ReturnEntity_IQueryable<Buyer> GetAllBuyers(string userId);
        ReturnEntity<Buyer> GetBuyerById(int id , string userId);
        Task<Result> CreateBuyer(Buyer buyer);
        Task<Result> DeleteBuyer(int id);
        Task<Result> EditBuyer(Buyer buyer);

    }
}
