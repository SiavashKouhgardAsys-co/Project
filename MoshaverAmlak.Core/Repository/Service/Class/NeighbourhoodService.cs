using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class NeighbourhoodService : INeighbourhoodService
    {
        private readonly INeighbourhoodRepository _neighbourhood;
        public NeighbourhoodService(INeighbourhoodRepository neighbourhood)
        {
            _neighbourhood = neighbourhood;
        }

        public ReturnEntity_IQueryable<Neighbourhood> GetAllNeighbourhood() => _neighbourhood.GetAllNeighbourhood();

        public ReturnEntity<Neighbourhood> GetNeighbourhoodById(int id) => _neighbourhood.GetNeighbourhoodById(id);
        public async Task<Result> CreateNeighbourhood(Neighbourhood neighbourhood) => await _neighbourhood.CreateNeighbourhood(neighbourhood);
        public async Task<Result> DeleteNeighbourhoodById(int id) => await _neighbourhood.DeleteNeighbourhoodById(id);

        public async Task<Result> EditNeighbourhood(Neighbourhood neighbourhood) => await
            _neighbourhood.EditNeighbourhood(neighbourhood);
    }
}
