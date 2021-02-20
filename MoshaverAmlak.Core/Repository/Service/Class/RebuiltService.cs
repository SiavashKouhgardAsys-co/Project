using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class RebuiltService
    {

        private readonly IRebuiltRepository _rebuilt;
        public RebuiltService(IRebuiltRepository rebuilt)
        {
            _rebuilt = rebuilt;
        }

        public ReturnEntity_IQueryable<Rebuilt> GetAllRebuilt() => _rebuilt.GetAllRebuilt();

        public ReturnEntity<Rebuilt> GetRebuiltById(int id) => _rebuilt.GetRebuiltById(id);
        public async Task<Result> CreateRebuilt(Rebuilt rebuilt) => await _rebuilt.CreateRebuilt(rebuilt);
        public async Task<Result> DeleteRebuilt(int id) => await _rebuilt.DeleteRebuiltById(id);

        public async Task<Result> EditRebuilt(Rebuilt rebuilt) => await
            _rebuilt.EditRebuilt(rebuilt);
    }
}
