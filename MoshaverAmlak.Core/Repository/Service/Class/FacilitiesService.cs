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
    public class FacilitiesService : IFacilitiesService
    {
        private readonly IFacilitiesRepository _facilities;
        public FacilitiesService(IFacilitiesRepository facilities)
        {
            _facilities = facilities;
        }

        public ReturnEntity_IQueryable<Facilities> GetAllFacilities() => _facilities.GetAllFacilities();

        public ReturnEntity<Facilities> GetFacilitiesById(int id) => _facilities.GetFacilityById(id);
        public async Task<Result> CreateFacilities(Facilities facilities) => await _facilities.CreateFacility(facilities);
        public async Task<Result> DeleteFacilities(int id) => await _facilities.DeleteFacilityById(id);

        public async Task<Result> EditFacilities(Facilities facilities) => await
            _facilities.EditFacility(facilities);
    }
}
