using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IFacilitiesService
    {
        ReturnEntity_List<FacilitiesViewmodel_Entity> GetAllFacilities();
        ReturnEntity<Facilities> GetFacilitiesById(int id);
        Task<Result> CreateFacilities(Facilities facilities);
        Task<Result> DeleteFacilities(int id);
        Task<Result> EditFacilities(Facilities facilities);
    }
}
