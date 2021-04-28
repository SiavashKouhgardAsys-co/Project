using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class InvestorRepository : IInvestorRepository
    {
        private readonly IGenericRepository<Investor> _investorRepository;
        public InvestorRepository(IGenericRepository<Investor> investorRepository)
        {
            _investorRepository = investorRepository;
        }

        public ReturnEntity_IQueryable<Investor> GetAllInvestors(string userId) => _investorRepository.GetAllEntityByOtherColumn(x => x.UserId == userId);
        
        public ReturnEntity<Investor> GetInvestorById(int id, string userId) => _investorRepository.GetEntityByOtherColumn(x => x.UserId == userId && x.Id == id);
        
        public async Task<Result> CreateInvestor(Investor investor)
        {
            var entity = await _investorRepository.AddEntity(investor);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            
            return await _investorRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteInvestor(int investorId)
        {
            var entity = _investorRepository.DeleteEntityById(investorId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            
            return await _investorRepository.SaveChangeAsync();
        }

        public async Task<Result> EditInvestor(Investor investor)
        {
            var entity = _investorRepository.GetEntityById(investor.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            
            entity.Entity.FullName = investor.FullName;
            entity.Entity.Description = investor.Description;
            entity.Entity.AmountOfInvestiment = investor.AmountOfInvestiment;

            var updateEntity = _investorRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;

            return await _investorRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _investorRepository?.Dispose();
        }
    }
}
