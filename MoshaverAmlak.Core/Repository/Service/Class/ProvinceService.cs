using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _province;
        public ProvinceService(IProvinceRepository province)
        {
            _province = province;
        }

        public ReturnEntity_IQueryable<Province> GetAllProvinces() => _province.GetAllProvince();

        public ReturnEntity<Province> GetProvinceById(int id) => _province.GetProvinceById(id);
        public async Task<Result> CreateProvince(Province province) => await _province.CreateProvince(province);
        public async Task<Result> DeleteProvince(int id) => await _province.DeleteProvince(id);

        public async Task<Result> EditProvince(Province province) => await
            _province.EditProvince(province);
    }
}
