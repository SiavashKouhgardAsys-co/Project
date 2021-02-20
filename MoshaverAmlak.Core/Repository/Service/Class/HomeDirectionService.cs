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
    public class HomeDirectionService : IHomeDirectionService
    {
        private readonly IHomeDirectionRepository _homeDirection;
        public HomeDirectionService(IHomeDirectionRepository homeDirection)
        {
            _homeDirection = homeDirection;
        }

        public ReturnEntity_IQueryable<HomeDirection> GetAllHomeDirection() => _homeDirection.GetAllHomeDirection();

        public ReturnEntity<HomeDirection> GetHomeDirectionById(int id) => _homeDirection.GetHomeDirectionById(id);
        public async Task<Result> CreateHomeDirection(HomeDirection homeDirection) => await _homeDirection.CreateHomeDirection(homeDirection);
        public async Task<Result> DeleteHomeDirection(int id) => await _homeDirection.DeleteHomeDirectionById(id);

        public async Task<Result> EditHomeDirection(HomeDirection homeDirection) => await
            _homeDirection.EditHomeDirection(homeDirection);
    }
}
 