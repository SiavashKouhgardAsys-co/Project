using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface INeighbourhoodService
    {
        ReturnEntity_IQueryable<Neighbourhood> GetAllNeighbourhood();
        ReturnEntity<Neighbourhood> GetNeighbourhoodById(int id);
        Task<Result> CreateNeighbourhood(Neighbourhood neighbourhood);
        Task<Result> DeleteNeighbourhoodById(int id);
        Task<Result> EditNeighbourhood(Neighbourhood neighbourhood);
    }
}
