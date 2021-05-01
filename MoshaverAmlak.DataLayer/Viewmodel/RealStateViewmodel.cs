using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoshaverAmlak.DataLayer.Viewmodel
{
    public class RealStateViewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Tel { get; set; }
    }

    public class RealStateTelViewmodel
    {
        public RealEstate RealState { get; set; }
        public RealEstateTel RealStateInfo { get; set; }
        public IQueryable<RealEstateTel> Tels { get; set; }
    }

    public class RealStateAddressViewmodel
    {
        public RealEstate RealState { get; set; }
        public RealEstateAddress AddressInfo { get; set; }
        public IQueryable<RealEstateAddress> Addresses { get; set; }
    }

    public class RealStateDetailsViewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string Description { get; set; }
        public IQueryable<RealEstateTel> RealEstateTels { get; set; }
        public IQueryable<RealEstateAddress> RealEstateAddresses { get; set; }
    }
}
