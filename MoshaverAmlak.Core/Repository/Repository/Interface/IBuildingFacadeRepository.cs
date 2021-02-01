using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    interface IBuildingFacadeRepository : IDisposable
    {
        ReturnEntity_IQueryable<BuildingFacade> GetAllBuildingFacade();
        ReturnEntity<BuildingFacade> GetBuildingFacadeById(int buildingFacade);
        Task<Result> CreateBuildingFacade(BuildingFacade buildingFacade);
        Task<Result> DeleteBuildingFacadeById(int buildingFacadeId);
        Task<Result> EditBuildungFacade(BuildingFacade buildingFacade);

    }
}
