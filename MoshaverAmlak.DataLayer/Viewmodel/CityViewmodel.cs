using System.Collections.Generic;
using System.Linq;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.DataLayer.Viewmodel
{
    public class CityViewmodel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
    public class CityViewmodel_Create
    {
        public City City { get; set; }
        public IQueryable<Province> Provinces { get; set; }
    }
    public class CityViewmodel_Edit
    {
        public CityViewmodel City { get; set; }
        public IQueryable<Province> Provinces { get; set; }
    }

}
