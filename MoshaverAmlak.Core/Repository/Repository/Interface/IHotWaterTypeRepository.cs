using System;
using System.Threading.Tasks;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IHotWaterTypeRepository : IDisposable
    {
        ReturnEntity_IQueryable<HotWaterType> GetAllHotWaterType();
        ReturnEntity<HotWaterType> GetHotWaterTypeById(int hotWaterTypeId);
        Task<Result> CraeteHotWaterType(HotWaterType hotWaterType);
        Task<Result> DeleteHotWaterTypeById(int hotWaterTypeId);
        Task<Result> UpdateHotWaterTypeById(HotWaterType hotWaterType);
    }
}
