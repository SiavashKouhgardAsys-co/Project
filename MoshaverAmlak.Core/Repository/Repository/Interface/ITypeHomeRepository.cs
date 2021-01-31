using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    interface ITypeHomeRepository : IDisposable
    {
        ReturnEntity_IQueryable<TypeHome> GetAllTypeHome();
        ReturnEntity<TypeHome> GetTypeHomeById(int typeHomeId);
        Task<Result> CreateTypeHome(TypeHome typeHome);
        Task<Result> DeleteTypeHomeById(int typeHomeId);
        Task<Result> EditTypeHome(TypeHome typeHome);
    }
}
