using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IHomeDirectionService
    {
        ReturnEntity_IQueryable<HomeDirection> GetAllHomeDirection();
        ReturnEntity<HomeDirection> GetHomeDirectionById(int id);
        Task<Result> CreateHomeDirection(HomeDirection homeDirection);
        Task<Result> DeleteHomeDirection(int id);
        Task<Result> EditHomeDirection(HomeDirection homeDirection);
    }
}
