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
    public class InvestorService : IInvestorService
    {
        private readonly IInvestorRepository _investor;
        private readonly IInvestorTelRepository _investorTel;

        public InvestorService(IInvestorRepository investor , IInvestorTelRepository investorTel)
        {
            _investor = investor;
            _investorTel = investorTel;
        }

        public ReturnEntity_List<InvestorViewmodel> GetAllInvestors(string userId) 
        {
            ReturnEntity_List<InvestorViewmodel> returnEntity = new ReturnEntity_List<InvestorViewmodel>();
            
            var data = _investor.GetAllInvestors(userId);
            returnEntity.Result = data.Result;
            if (data.Result.StatusResult != (int)Result.Status.OK) return returnEntity;

            List<InvestorViewmodel> investorViewmodels = new List<InvestorViewmodel>();

            foreach (var item in data.Entity)
            {
                Investor investor = new Investor()
                {
                    Id = item.Id
                };

                var telInfo = _investorTel.GetInvestorTelById(investor.Id);
                returnEntity.Result = telInfo.Result;

                string tempTel = "";
                if (telInfo.Entity == null)
                    tempTel = " - ";
                else
                    tempTel = telInfo.Entity.Tel;

                if (telInfo.Result.StatusResult != (int)Result.Status.OK) return returnEntity;

                investorViewmodels.Add(new InvestorViewmodel()
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Description = item.Description,
                    Tel = tempTel 
                });
            }
            returnEntity.Entity = investorViewmodels;
            return returnEntity;
        }

        public ReturnEntity<Investor> GetInvestorById(int id, string userId) => _investor.GetInvestorById(id, userId);
        public ReturnEntity<InvestorDetailsViewmodel> GetInvestorByIdForDetails(int id , string userId) 
        {
            ReturnEntity<InvestorDetailsViewmodel> returnEntity = new ReturnEntity<InvestorDetailsViewmodel>();
            
            var dataInvestorTel = _investorTel.GetAllInvestorTelById(id);
            if (dataInvestorTel.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            
            var dataInvestor = _investor.GetInvestorById(id, userId);
            if (dataInvestor.Result.StatusResult != (int)Result.Status.OK) return returnEntity;

            returnEntity.Entity = new InvestorDetailsViewmodel()
            {
                Id = dataInvestor.Entity.Id,
                FullName = dataInvestor.Entity.FullName,
                Description = dataInvestor.Entity.Description,
                Tels = dataInvestorTel.Entity
            };

            return returnEntity;
        }

        public ReturnEntity<InvestorTel> GetInvestorTelById(int id) => _investorTel.GetInvestorTelById(id);

        public ReturnEntity_IQueryable<InvestorTel> GetAllInvestorTelByUserId(int id) => _investorTel.GetAllInvestorTelById(id);

        public async Task<Result> CreateInvestor(Investor investor) => await _investor.CreateInvestor(investor);
        public async Task<Result> CreateInvestorTel(InvestorTel investorTel) => await _investorTel.CreateInvestorTel(investorTel);
        public async Task<Result> DeleteInvestor(int id) => await _investor.DeleteInvestor(id);
        public async Task<Result> DeleteInvestorTel(int id) => await _investorTel.DeleteInvestorTel(id);
        public async Task<Result> EditInvestor(Investor investor) => await _investor.EditInvestor(investor);
    } 
}
