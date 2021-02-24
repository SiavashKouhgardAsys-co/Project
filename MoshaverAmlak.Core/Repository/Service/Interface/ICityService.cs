using System.Threading.Tasks;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface ICityService
    {
        ReturnEntity_List<CityViewmodel> GetAllCities();
        ReturnEntity<CityViewmodel> GetCityById(int id);
        Task<Result> CreateCity(City city);
        Task<Result> DeleteCity(int id);
        Task<Result> EditCity(CityViewmodel cityViewmodel);
    }
}
