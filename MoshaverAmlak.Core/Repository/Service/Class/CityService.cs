using System.Collections.Generic;
using System.Threading.Tasks;
using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _city;
        private readonly IProvinceService _provinceService;
        public CityService(ICityRepository city, IProvinceService provinceService)
        {
            _city = city;
            _provinceService = provinceService;
        }

        public ReturnEntity_List<CityViewmodel> GetAllCities()
        {
            ReturnEntity_List<CityViewmodel> returnEntity = new ReturnEntity_List<CityViewmodel>();
            var cities = _city.GetAllCities();
            returnEntity.Result = cities.Result;
            if (cities.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            List<CityViewmodel> cityList = new List<CityViewmodel>();
            foreach (var item in cities.Entity)
            {
                var province = _provinceService.GetProvinceById(item.ProvinceId);
                returnEntity.Result = province.Result;
                if (province.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
                cityList.Add(new CityViewmodel()
                {
                    CityId = item.Id,
                    CityName = item.Name,
                    ProvinceId = item.ProvinceId,
                    ProvinceName = province.Entity.Name
                });
            }
            returnEntity.Entity = cityList;
            return returnEntity;
        }
        public ReturnEntity<CityViewmodel> GetCityById(int id)
        {
            ReturnEntity<CityViewmodel> returnEntity = new ReturnEntity<CityViewmodel>();
            var city = _city.GetCityById(id);
            returnEntity.Result = city.Result;
            if (city.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            var province = _provinceService.GetProvinceById(city.Entity.ProvinceId);
            returnEntity.Result = province.Result;
            if (province.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            returnEntity.Entity = new CityViewmodel()
            {
                CityId = city.Entity.Id,
                CityName = city.Entity.Name,
                ProvinceId = province.Entity.Id,
                ProvinceName = province.Entity.Name
            };
            return returnEntity;
        }
        public async Task<Result> CreateCity(City city) => await _city.CreateCity(city);
        public async Task<Result> DeleteCity(int id) => await _city.DeleteCity(id);
        public async Task<Result> EditCity(CityViewmodel cityViewmodel)
        {
            var city = _city.GetCityById(cityViewmodel.CityId);
            city.Entity.Name = cityViewmodel.CityName;
            city.Entity.ProvinceId = cityViewmodel.ProvinceId;
            return await _city.EditCity(city.Entity);
        }
    }
}
