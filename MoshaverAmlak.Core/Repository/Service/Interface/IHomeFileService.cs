using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IHomeFileService
    {
        ReturnEntity_IQueryable<HomeFile> GetAllHomeFile();
        ReturnEntity<HomeFile> GetHomeFileById(int id);
        ReturnEntity_List<HomeFileViewmodel> GetAllHomeFiles();
        Task<Result> CreateHomeFile(HomeFile homeFile);
        Task<Result> DeleteHomeFile(int id);
        Task<Result> EditHomeFile(HomeFile homeFile);
    }
}
