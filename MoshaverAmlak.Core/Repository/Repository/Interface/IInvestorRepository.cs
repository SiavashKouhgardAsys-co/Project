using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IInvestorRepository
    {
        ReturnEntity_IQueryable<Investor> GetAllInvestors(string userId);
        ReturnEntity<Investor> GetInvestorById(int id, string userId);
        Task<Result> CreateInvestor(Investor investor);
        Task<Result> DeleteInvestor(int investorId);
        Task<Result> EditInvestor(Investor investor);
        void Dispose();
    }
}
