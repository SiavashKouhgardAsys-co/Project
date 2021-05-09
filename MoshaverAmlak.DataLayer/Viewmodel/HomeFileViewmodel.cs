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
        public string HomeFileType { get; set; }
        public string Area { get; set; }
        public long FinalPrice { get; set; }
    }

    public class HomeFileCreateViewmodel
    {
        public Owner Owner { get; set; }
        public IQueryable<Region> Region { get; set; }
        public IQueryable<TypeOfDocument> Documents { get; set; }
        public IQueryable<Facilities> Facilities { get; set; }
        public IQueryable<CategoryFacilities> CategoryFacilities { get; set; }
        public IQueryable<Neighbourhood> Neighbourhoods { get; set; }
        public IQueryable<Rebuilt> Rebuilts { get; set; }
        public IQueryable<HomeDirection> HomeDirections { get; set; }
        public IQueryable<HomeFileType> HomeFileTypes { get; set; }
        public IQueryable<FileType> FileTypes { get; set; }
        public IQueryable<TypeOfDocument> TypeOfDocuments { get; set; }
    }
    
    
}
