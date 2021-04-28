using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IInvestorTelRepository
    {
        ReturnEntity<string> GetAllTels(int id);
        ReturnEntity_IQueryable<InvestorTel> GetAllInvestorTel();
        ReturnEntity_IQueryable<InvestorTel> GetAllInvestorTelById(int id);
        ReturnEntity<InvestorTel> GetInvestorTelById(int investorId);
        Task<Result> CreateInvestorTel(InvestorTel investorTel);
        Task<Result> DeleteInvestorTel(int investorId);
    }
}
