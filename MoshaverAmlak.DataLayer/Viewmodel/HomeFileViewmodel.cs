using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoshaverAmlak.DataLayer.Viewmodel
{
    public class HomeFileViewmodel
    {
        public int HomeFileId { get; set; }
        public FileType HomeFileType { get; set; }
        public double Area { get; set; }
        public long FinalPrice { get; set; }
    }

    public class HomeFileCreateViewmodel
    {
        public Owner Owner { get; set; }

        public IQueryable<Region> Region { get; set; }
        public IQueryable<TypeOfDocument> Documents { get; set; }
        public IQueryable<Neighbourhood> Neighbourhoods { get; set; }
        public IQueryable<Rebuilt> Rebuilts { get; set; }
        public IQueryable<HomeDirection> HomeDirections { get; set; }
        public IQueryable<HomeFileType> HomeFileTypes { get; set; }
        public IQueryable<FileType> FileTypes { get; set; }
        public IQueryable<TypeOfDocument> TypeOfDocuments { get; set; }
        public List<HomeFileCreateFacilityViewModel> ForFacilities { get; set; }
    }

    public class HomeFileCreateFacilityViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IQueryable<Facilities> Facilities { get; set; }
    }

}
