using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    interface IFloorMaterialRepository : IDisposable
    {
        ReturnEntity_IQueryable<FloorMaterial> GetAllFloorMaterial();
        ReturnEntity<FloorMaterial> GetFloorMaterialById(int floorMaterialId);
        Task<Result> CreateFloorMaterial(FloorMaterial floorMaterial);
        Task<Result> DeleteFloorMaterialById(int floorMaterialId);
        Task<Result> EditFloorMaterial(FloorMaterial floorMaterial);
    }
}
