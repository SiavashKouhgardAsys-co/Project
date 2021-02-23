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
    class CityService : ICityService
    {
        private readonly ICityRepository _city;
        public CityService(ICityRepository city)
        {
            _city = city;
        }

        public ReturnEntity_IQueryable<City> GetAllCities() => _city.GetAllCities();

        public ReturnEntity<City> GetCityById(int id) => _city.GetCityById(id);
        public async Task<Result> CreateCity(City city) => await _city.CreateCity(city);
        public async Task<Result> DeleteCity(int id) => await _city.DeleteCity(id);

        public async Task<Result> EditCity(City city) => await
            _city.EditCity(city);
    }
}
