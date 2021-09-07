using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class FacilitiesService : IFacilitiesService
    {
        private readonly IFacilitiesRepository _facilities;
        private readonly ICategoryFacilitiesService _categoryFacilitiesService;
        public FacilitiesService(IFacilitiesRepository facilities, ICategoryFacilitiesService categoryFacilitiesService)
        {
            _facilities = facilities;
            _categoryFacilitiesService = categoryFacilitiesService;
        }

        public ReturnEntity_List<FacilitiesViewmodel_Entity> GetAllFacilities()
        {
            ReturnEntity_List<FacilitiesViewmodel_Entity> returnEntity = new ReturnEntity_List<FacilitiesViewmodel_Entity>();
            var facilities = _facilities.GetAllFacilities();
            returnEntity.Result = facilities.Result;
            if (facilities.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
            List<FacilitiesViewmodel_Entity> facilitiesViewmodel = new List<FacilitiesViewmodel_Entity>();
            foreach (var item in facilities.Entity)
            {
                var category = _categoryFacilitiesService.GetCategoryFacilitiesById(item.CategoryFacilityId);
                returnEntity.Result = category.Result;
                if (category.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
                facilitiesViewmodel.Add(new FacilitiesViewmodel_Entity()
                {
                    CategoryFacilityId = item.CategoryFacilityId,
                    CategeryFacilityName = category.Entity.Name,
                    FacilityId = item.Id,
                    FacilityName = item.Name

                });
            }
            returnEntity.Entity = facilitiesViewmodel;
            return returnEntity;
        }


        public ReturnEntity<Facilities> GetFacilitiesById(int id) => _facilities.GetFacilityById(id);
        public ReturnEntity_List<HomeFileCreateFacilityViewModel> GetFacilityByCategory()
        {
            ReturnEntity_List<HomeFileCreateFacilityViewModel> returnEntity = new ReturnEntity_List<HomeFileCreateFacilityViewModel>();
            List<HomeFileCreateFacilityViewModel> homeFileCreateFacilityViewModels = new List<HomeFileCreateFacilityViewModel>();
            var category = _categoryFacilitiesService.GetAllCategoryFacilities();
            foreach (var item in category.Entity)
            {
                var facility = _facilities.GetRangeFacilityByCategoryId(item.Id);
                if (facility.Result.StatusResult != (int)Result.Status.OK) return returnEntity;
                returnEntity.Result = facility.Result;
                homeFileCreateFacilityViewModels.Add(new HomeFileCreateFacilityViewModel
                {
                    CategoryId = item.Id,
                    CategoryName = item.Name,
                    Facilities = facility.Entity
                });
            }
            returnEntity.Entity = homeFileCreateFacilityViewModels;
            return returnEntity;
        }
        public async Task<Result> CreateFacilities(Facilities facilities) => await _facilities.CreateFacility(facilities);
        public async Task<Result> DeleteFacilities(int id) => await _facilities.DeleteFacilityById(id);
        public async Task<Result> EditFacilities(Facilities facilities) => await
            _facilities.EditFacility(facilities);
    }
}
