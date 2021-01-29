using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MoshaverAmlak.DataLayer.Entity
{
    public class RealEstate_User : IdentityUser
    {
        public string FullName { get; set; }

        public ICollection<UserRegion> UserRegions { get; set; }
        public ICollection<RealEstate> RealEstates { get; set; }
        public ICollection<Owner> Owners { get; set; }
        public ICollection<Buyer> Buyers { get; set; }
        public ICollection<Investor> Investors { get; set; }
        public ICollection<UserWorkArea> UserWorkAreas { get; set; }
    }
}
