using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    class ProvinceRepository
    {
        private readonly IGenericRepository<Province> _provinceRepository;
        public ProvinceRepository(IGenericRepository<Province> provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public ReturnEntity_IQueryable<Province> GetAllProvince() => _provinceRepository.GetAllEntity();
        public ReturnEntity<Province> GetProvinceById(int provinceId) => _provinceRepository.GetEntityById(provinceId);

        public async Task<Result> CreateProvince(Province province)
        {
            var entity = _provinceRepository.AddEntity(province);
            if (entity.Status != (int)Result.Status.OK) return await entity;
            return await _provinceRepository.SaveChangeAsync();
        }


        public async Task<Result> DeleteProvince(int provinceId)
        {
            var entity = _provinceRepository.DeleteEntityById(provinceId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _provinceRepository.SaveChangeAsync();
        }

        public async Task<Result> EditProvince(Province province)
        {
            var entity = GetProvinceById(province.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = province.Name;
            var update_entity = _provinceRepository.UpdateEntity(entity.Entity);
            if (update_entity.StatusResult != (int)Result.Status.OK) return update_entity;
            return await _provinceRepository.SaveChangeAsync();
        }


        public void Dispose()
        {
            _provinceRepository?.Dispose();
        }
    }
}
