using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IHomeFileTypeService
    {
        ReturnEntity_IQueryable<HomeFileType> GetAllHomeFileType();
        ReturnEntity<HomeFileType> GetHomeFileTypeById(int id);
        Task<Result> CreateHomeFileType(HomeFileType homeFileType);
        Task<Result> DeleteHomeFileType(int id);
        Task<Result> EditHomeFileType(HomeFileType homeFileType);
    }
}
