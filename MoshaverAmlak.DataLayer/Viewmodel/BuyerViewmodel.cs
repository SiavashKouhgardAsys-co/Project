using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoshaverAmlak.DataLayer.Viewmodel
{
    
    public class BuyerViewmodel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FromInvestment { get; set; }
        public string ToInvestment { get; set; }
        public string Description { get; set; }
        public string Tel { get; set; }
    }

    public class BuyerTelViewmodel
    {
        public Buyer Buyer { get; set; }

        public BuyerTel BuyerInfo { get; set; }
        public IQueryable<BuyerTel> Tels { get; set; }
    }
    
}
