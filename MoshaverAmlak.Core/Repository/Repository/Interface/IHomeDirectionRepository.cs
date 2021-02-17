using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IHomeDirectionRepository : IDisposable
    {
        ReturnEntity_IQueryable<HomeDirection> GetAllHomeDirection();
        ReturnEntity<HomeDirection> GetHomeDirectionById(int homeDirectionId);
        Task<Result> CreateHomeDirection(HomeDirection homeDirection);
        Task<Result> DeleteHomeDirectionById(int homeDirectionId);
        Task<Result> EditHomeDirection(HomeDirection homeDirection);


    }
}
