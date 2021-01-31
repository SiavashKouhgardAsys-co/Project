using System;
using System.Threading.Tasks;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IHeatingTypeRepository : IDisposable
    {
        ReturnEntity_IQueryable<HeatingType> GetAllHeatingType();
        ReturnEntity<HeatingType> GetHeatingTypeById(int heatingTypeId);
        Task<Result> CreateHeatingType(HeatingType heatingType);
        Task<Result> UpdateHeatingType(HeatingType heatingType);
        Task<Result> DeleteHeatingType(int heatingTypeId);
    }
}
