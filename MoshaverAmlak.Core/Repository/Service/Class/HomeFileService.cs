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
    public class HomeFileService : IHomeFileService
    {
        private readonly IHomeFileRepository _homeFile;
        public HomeFileService(IHomeFileRepository homeFile)
        {
            _homeFile = homeFile;
        }

        public ReturnEntity_IQueryable<HomeFile> GetAllHomeFile() => _homeFile.GetAllHomeFile();

        public ReturnEntity<HomeFile> GetHomeFileById(int id) => _homeFile.GetHomeFileById(id);

        public async Task<Result> CreateHomeFile(HomeFile homeFile) => await _homeFile.CreateHomeFile(homeFile);
    }
}
