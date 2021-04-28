using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoshaverAmlak.DataLayer.Viewmodel
{
    public class InvestorViewmodel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string AmountOfInvestiment { get; set; }
        public string Description { get; set; }
        public string Tel { get; set; }
    }

    public class InvestorTelViewmodel
    {
        public Investor Investor { get; set; }
        public InvestorTel InvestorInfo { get; set; }
        public IQueryable<InvestorTel> Tels { get; set; }
    }

    public class InvestorDetailsViewmodel
    {
        public int Id { get; set; }
        public string  FullName { get; set; }
        public string AmountOfInvestiment { get; set; }
        public string Description { get; set; }
        public IQueryable<InvestorTel> Tels { get; set; }
    }

}
