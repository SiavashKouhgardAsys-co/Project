using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public IQueryable<CategoryFacilities> CategoryFacilities{ get; set; }
        public Facilities Facilities { get; set; }
    }
}
