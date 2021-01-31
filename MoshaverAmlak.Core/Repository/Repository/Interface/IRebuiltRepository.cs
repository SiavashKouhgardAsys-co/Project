using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    interface IRebuiltRepository : IDisposable
    {
        Task<Result> EditRebuilt(Rebuilt rebuilt);
        Task<Result> DeleteRebuiltById(int rebuiltId);
        Task<Result> CreateRebuilt(Rebuilt rebuilt);
        ReturnEntity_IQueryable<Rebuilt> GetAllRebuilt();
        ReturnEntity<Rebuilt> GetRebuiltById(int rebuiltId);
    }
}
