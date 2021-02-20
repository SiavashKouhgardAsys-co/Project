using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IRebuiltService
    {
        ReturnEntity_IQueryable<Rebuilt> GetAllRebuilt();
        ReturnEntity<Rebuilt> GetRebuiltById(int id);
        Task<Result> CreateRebuilt(Rebuilt rebuilt);
        Task<Result> DeleteRebuilt(int id);
        Task<Result> EditRebuilt(Rebuilt rebuilt);
    }

}
