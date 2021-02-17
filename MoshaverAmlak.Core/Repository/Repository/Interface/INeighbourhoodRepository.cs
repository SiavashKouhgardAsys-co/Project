using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface INeighbourhoodRepository : IDisposable
    {
        ReturnEntity_IQueryable<Neighbourhood> GetAllNeighbourhood();
        ReturnEntity<Neighbourhood> GetNeighbourhoodById(int neighbourhoodId);
        Task<Result> CreateNeighbourhood(Neighbourhood neighbourhood);
        Task<Result> DeleteNeighbourhoodById(int neighbourhoodId);
        Task<Result> EditNeighbourhood(Neighbourhood neighbourhood);
    }
}
