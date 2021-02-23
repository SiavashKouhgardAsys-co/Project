using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IProvinceService 
    {
        ReturnEntity_IQueryable<Province> GetAllProvinces();
        ReturnEntity<Province> GetProvinceById(int id);
        Task<Result> CreateProvince(Province province);
        Task<Result> DeleteProvince(int id);
        Task<Result> EditProvince(Province province);
    }
}
