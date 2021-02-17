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
    public class HomeFileTypeService : IHomeFileTypeService
    {
        private readonly IHomeFileTypeRepository _homeFileType;

        public HomeFileTypeService(IHomeFileTypeRepository homeFileType)
        {
            _homeFileType = homeFileType;
        }

        public ReturnEntity_IQueryable<HomeFileType> GetAllHomeFileType() =>
            _homeFileType.GetAllHomeFileType();

        public ReturnEntity<HomeFileType> GetHomeFileTypeById(int id) =>
            _homeFileType.GetHomeFileTypeById(id);

        public async Task<Result> CreateHomeFileType(HomeFileType homeFileType) => await _homeFileType.CreateHomeFileType(homeFileType);
        public async Task<Result> DeleteHomeFileType(int id) =>
           await _homeFileType.DeleteHomeFileTypeById(id);

        public async Task<Result> EditHomeFileType(HomeFileType homeFileType) => await _homeFileType.EditHomeFileType(homeFileType);
    }
}
