using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface ICityRepository : IDisposable
    {
        ReturnEntity_IQueryable<City> GetAllCities();
        ReturnEntity<City> GetCityById(int cityId);
        Task<Result> CreateCity(City city);
        Task<Result> DeleteCity(int cityId);
        Task<Result> EditCity(City city);


    }
}
