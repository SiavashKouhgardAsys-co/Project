using System;
using System.Threading.Tasks;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IAirConditionerRepository : IDisposable
    {
        ReturnEntity_IQueryable<AirConditioner> GetAllAirConditioner();
        ReturnEntity<AirConditioner> GetAirConditionerById(int airConditionerId);
        Task<Result> CreateAirConditioner(AirConditioner airConditioner);
        Task<Result> DeleteAirConditionerById(int airConditionerId);
        Task<Result> UpdateAirConditioner(AirConditioner airConditioner);
    }
}
