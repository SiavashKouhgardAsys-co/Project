using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface IProvinceRepository
    {
        ReturnEntity_IQueryable<Province> GetAllProvince();
        ReturnEntity<Province> GetProvinceById(int provinceId);
        Task<Result> CreateProvince(Province province);
        Task<Result> DeleteProvince(int provinceId);
        Task<Result> EditProvince(Province province);


    }
}
