using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
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

        public ReturnEntity_List<HomeFileViewmodel> GetAllHomeFiles()
        {
            ReturnEntity_List<HomeFileViewmodel> returnEntity = new ReturnEntity_List<HomeFileViewmodel>();

            var data = _homeFile.GetAllHomeFile();
            returnEntity.Result = data.Result;
            if (data.Result.StatusResult != (int)Result.Status.OK) return returnEntity;

            List<HomeFileViewmodel> homeFileViewmodels = new List<HomeFileViewmodel>();
            foreach (var item in data.Entity)
            {
                homeFileViewmodels.Add(new HomeFileViewmodel() 
                {
                    Id = item.Id,
                    OnwerName = item.OwnerName,
                    OwnerNumber = item.OwnerNumber,
                    Address = item.Address,
                    Description = item.Description,
                    Region = item.Region,
                    FinalPrice = item.FinalPrice,
                    HomeFileType = item.HomeFileType,
                    HomeDirection = item.HomeDirection,
                    Neighbourhood = item.Neighbourhood,
                    YearOfConstruction = item.YearOfConstruction
                   
                });
            }

            returnEntity.Entity = homeFileViewmodels;
            return returnEntity;
        } 

        public ReturnEntity<HomeFile> GetHomeFileById(int id) => _homeFile.GetHomeFileById(id);

        public async Task<Result> CreateHomeFile(HomeFile homeFile) => await _homeFile.CreateHomeFile(homeFile);

        public async Task<Result> DeleteHomeFile(int id) => await _homeFile.DeleteHomeFile(id);
        public async Task<Result> EditHomeFile(HomeFile homeFile) => await _homeFile.EditHomeFile(homeFile);

    }
}
