using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class InvestorTelRepository : IInvestorTelRepository
    {
        private readonly IGenericRepository<InvestorTel> _investorRepository;
        public InvestorTelRepository(IGenericRepository<InvestorTel> investorTelRepository)
        {
            _investorRepository = investorTelRepository;
        }

        public ReturnEntity<string> GetAllTels(int id)
        {
            ReturnEntity<string> returnEntity = new ReturnEntity<string>();
            var data = _investorRepository.GetAllEntityByOtherColumn(x => x.InvestorId == id);
            returnEntity.Result = data.Result;
            if (data.Result.StatusResult != (int)Result.Status.OK) return returnEntity;

            string tels = "";
            var telList = data.Entity.ToList();
            for (int i = 0; i < telList.Count(); i++)
            {
                tels += telList[i].Tel;
                if (i < telList.Count())
                {
                    tels += " - ";
                }
            }
            returnEntity.Entity = tels;
            return returnEntity;
        }

        public ReturnEntity_IQueryable<InvestorTel> GetAllInvestorTel() => _investorRepository.GetAllEntity();

        public ReturnEntity_IQueryable<InvestorTel> GetAllInvestorTelById(int id) => _investorRepository.GetAllEntityByOtherColumn(x => x.InvestorId == id);

        public ReturnEntity<InvestorTel> GetInvestorTelById(int investorId) => _investorRepository.GetEntityByOtherColumn(x => x.InvestorId == investorId);

        public async Task<Result> CreateInvestorTel(InvestorTel investorTel)
        {
            var entity = await _investorRepository.AddEntity(investorTel);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _investorRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteInvestorTel(int investorId)
        {
            var entity = _investorRepository.DeleteEntityById(investorId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _investorRepository.SaveChangeAsync();
        }

        
    }
}
