using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IHomeFileTypeRepository : IDisposable
    {
        ReturnEntity_IQueryable<HomeFileType> GetAllHomeFileType();
        ReturnEntity<HomeFileType> GetHomeFileTypeById(int homeFileTypeId);
        Task<Result> CreateHomeFileType(HomeFileType homeFileType);

        Task<Result> DeleteHomeFileTypeById(int homeFileTypeId);
        Task<Result> EditHomeFileType(HomeFileType homeFileType);



    }
}
