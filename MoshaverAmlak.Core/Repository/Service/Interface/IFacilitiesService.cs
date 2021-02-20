using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IFacilitiesService
    {
        ReturnEntity_IQueryable<Facilities> GetAllFacilities();
        ReturnEntity<Facilities> GetFacilitiesById(int id);
        Task<Result> CreateFacilities(Facilities facilities);
        Task<Result> DeleteFacilities(int id);
        Task<Result> EditFacilities(Facilities facilities);
    }
}
