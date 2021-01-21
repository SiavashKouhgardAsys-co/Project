using System;
using System.Collections.Generic;
using System.Text;

namespace MoshaverAmlak.DataLayer.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsDelete { get; set; }
    }
}
