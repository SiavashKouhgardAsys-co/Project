using MoshaverAmlak.DataLayer.Entity;
using System.Linq;

namespace MoshaverAmlak.DataLayer.Viewmodel
{
    public class FacilitiesViewmodel_Entity
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public int CategoryFacilityId { get; set; }
        public string  CategeryFacilityName { get; set; }

    }

    public class FacilitiesViewmodel_Create
    {
        public Facilities Facilities { get; set; }
        public IQueryable<CategoryFacilities> CategoryFacilities{ get; set; }
    }

    public class FacilitiesViewmodel_Edit
    {
        public FacilitiesViewmodel_Entity Facilities { get; set; }
        public IQueryable<CategoryFacilities> CategoryFacilities { get; set; }
    }
}
