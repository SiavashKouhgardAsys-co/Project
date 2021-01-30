using System;
using System.Threading.Tasks;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IRoomRepository : IDisposable
    {
        ReturnEntity_IQueryable<Room> GetAllRoom();
        ReturnEntity<Room> GetRoomById(int roomId);
        Task<Result> CreateRoom(Room room);
    }
}
