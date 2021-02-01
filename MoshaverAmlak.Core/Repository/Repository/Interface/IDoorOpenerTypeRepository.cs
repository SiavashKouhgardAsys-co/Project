using System;
using System.Threading.Tasks;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IDoorOpenerTypeRepository : IDisposable
    {
        ReturnEntity_IQueryable<DoorOpenerType> GetAllDoorOpenerType();
        ReturnEntity<DoorOpenerType> GetDoorOpenerTypeById(int doorOpenerTypeId);
        Task<Result> CreateDoorOpenerType(DoorOpenerType doorOpenerType);
        Task<Result> UpdateDoorOpenerType(DoorOpenerType doorOpenerType);
        Task<Result> DeleteDoorOpenerTypeById(int doorOpenerTypeId);
    }
}
