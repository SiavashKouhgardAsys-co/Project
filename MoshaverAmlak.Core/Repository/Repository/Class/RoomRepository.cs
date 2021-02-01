using System.Threading.Tasks;
using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IGenericRepository<Room> _roomRepository;
        public RoomRepository(IGenericRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public ReturnEntity_IQueryable<Room> GetAllRoom() => _roomRepository.GetAllEntity();
        public ReturnEntity<Room> GetRoomById(int roomId) => _roomRepository.GetEntityById(roomId);
        public async Task<Result> CreateRoom(Room room)
        {
            var entity = _roomRepository.AddEntity(room);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _roomRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteRoomById(int roomId)
        {
            var entity = _roomRepository.DeleteEntityById(roomId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _roomRepository.SaveChangeAsync();
        }

        public async Task<Result> EditRoom(Room room)
        {
            var entity = _roomRepository.GetEntityById(room.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = room.Name;
            var updateEntity = _roomRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _roomRepository.SaveChangeAsync();
        }
        public void Dispose()
        {
            _roomRepository?.Dispose();
        }
    }
}
