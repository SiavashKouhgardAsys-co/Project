using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IInvestorService
    {
        ReturnEntity_List<InvestorViewmodel> GetAllInvestors(string userId);
        ReturnEntity<Investor> GetInvestorById(int id, string userId);
        ReturnEntity<InvestorDetailsViewmodel> GetInvestorByIdForDetails(int id, string userId);
        ReturnEntity<InvestorTel> GetInvestorTelById(int id);
        ReturnEntity_IQueryable<InvestorTel> GetAllInvestorTelByUserId(int id);
        Task<Result> CreateInvestor(Investor investor);
        Task<Result> CreateInvestorTel(InvestorTel investorTel);
        Task<Result> DeleteInvestor(int id);
        Task<Result> DeleteInvestorTel(int id);
        Task<Result> EditInvestor(Investor investor);
    }
}
