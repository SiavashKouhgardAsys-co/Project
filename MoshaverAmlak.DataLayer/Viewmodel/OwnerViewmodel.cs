using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoshaverAmlak.DataLayer.Viewmodel
{
    public class OwnerViewmodel
    {
        public  int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Tel { get; set; }
    }

    public class OwnerTelViewmodel
    {
        public Owner Owner { get; set; }
        public OwnerTel OwnerInfo { get; set; }
        public IQueryable<OwnerTel> Tels { get; set; }
    }

    public class OwnerDetailsViewmodel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public IQueryable<OwnerTel> Tels { get; set; }
    }
}
