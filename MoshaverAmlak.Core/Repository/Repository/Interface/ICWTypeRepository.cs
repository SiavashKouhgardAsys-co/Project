using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface ICWTypeRepository : IDisposable
    {
        ReturnEntity_IQueryable<CWType> GetAllCWType();
        ReturnEntity<CWType> GetCWTypeById(int cwTypeRepository);
        Task<Result> CreateCWType(CWType cWType);
        Task<Result> DeleteCWTypeById(int cwTypeId);
        Task<Result> EditCWType(CWType cWType);
    }
}
