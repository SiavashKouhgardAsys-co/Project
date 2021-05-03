using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IHomeFileRepository : IDisposable
    {
        ReturnEntity_IQueryable<HomeFile> GetAllHomeFile();
        ReturnEntity<HomeFile> GetHomeFileById(int id);
        Task<Result> CreateHomeFile(HomeFile homeFile);
        Task<Result> DeleteHomeFile(int homeFileId);
        Task<Result> EditHomeFile(HomeFile homeFile);
        
    }
}
