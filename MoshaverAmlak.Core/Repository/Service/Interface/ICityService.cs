using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface ICityService
    {
        ReturnEntity_IQueryable<City> GetAllCities();
        ReturnEntity<City> GetCityById(int id);
        Task<Result> CreateCity(City city);
        Task<Result> DeleteCity(int id);
        Task<Result> EditCity(City city);
    }
}
