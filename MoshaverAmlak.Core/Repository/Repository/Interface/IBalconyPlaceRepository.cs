using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    interface IBalconyPlaceRepository : IDisposable
    {
        ReturnEntity_IQueryable<BalconyPlace> GetAllBalconyPlace();
        ReturnEntity<BalconyPlace> GetBalconyPlaceById(int balconyPlaceId);
        Task<Result> CreateBalconyPlace(BalconyPlace balconyPlace);
        Task<Result> DeleteBalconyPlaceById(int balconyPlaceId);
        Task<Result> EditBalconyPlace(BalconyPlace balconyPlace);

    }
}
