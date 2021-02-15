using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MoshaverAmlak.DataLayer.Entity
{
    public class RealEstate_Context : IdentityDbContext<RealEstate_User, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public RealEstate_Context(DbContextOptions<RealEstate_Context> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FacilitiesHomeFile>().HasKey(x => x.Id);
            builder.Entity<FacilitiesHomeFile>().Property(x => x.Id)
                                                .ValueGeneratedOnAdd()
                                                .UseIdentityColumn(1, 1);
            builder.Entity<FacilitiesHomeFile>().HasOne(x => x.Facilities).WithMany(x => x.FacilitiesHomeFiles).HasForeignKey(x => x.FacilitiesId);
            builder.Entity<FacilitiesHomeFile>().HasOne(x => x.HomeFile).WithMany(x => x.FacilitiesHomeFiles).HasForeignKey(x => x.HomeFileId);

            builder.Entity<HomeFile>().HasKey(x => x.Id);
            builder.Entity<HomeFile>().Property(x => x.Id)
                                       .ValueGeneratedOnAdd()
                                       .UseIdentityColumn(1, 1);
            builder.Entity<HomeFile>().HasOne(x => x.Region).WithMany(x => x.HomeFiles).HasForeignKey(x => x.RegionId);
            builder.Entity<HomeFile>().HasOne(x => x.Neighbourhood).WithMany(x => x.HomeFiles).HasForeignKey(x => x.NeighbourhoodId);
            builder.Entity<HomeFile>().HasOne(x => x.Rebuilt).WithMany(x => x.HomeFiles).HasForeignKey(x => x.RebuiltId);
            builder.Entity<HomeFile>().HasOne(x => x.City).WithMany(x => x.HomeFiles).HasForeignKey(x => x.CityId);
            builder.Entity<HomeFile>().HasOne(x => x.HomeDirection).WithMany(x => x.HomeFiles).HasForeignKey(x => x.HomeDirectionId);
           
            builder.Entity<HomeFile>().HasOne(x => x.TypeOfDocument).WithMany(x => x.HomeFiles).HasForeignKey(x => x.TypeOfDocumentId);
            builder.Entity<HomeFile>().HasOne(x => x.HomeFileType).WithMany(x => x.HomeFiles).HasForeignKey(x => x.HomeFileTypeId);
            builder.Entity<HomeFile>().HasOne(x => x.FileType).WithMany(x => x.HomeFiles).HasForeignKey(x => x.FileTypeId);

            builder.Entity<HomeFileType>().HasKey(x => x.Id);
            builder.Entity<HomeFileType>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<FileType>().HasKey(x => x.Id);
            builder.Entity<FileType>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<Region>().HasKey(x => x.Id);
            builder.Entity<Region>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            


            builder.Entity<Neighbourhood>().HasKey(x => x.Id);
            builder.Entity<Neighbourhood>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<Rebuilt>().HasKey(x => x.Id);
            builder.Entity<Rebuilt>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<City>().HasKey(x => x.Id);
            builder.Entity<City>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<Province>().HasKey(x => x.Id);
            builder.Entity<Province>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            

            builder.Entity<ImageHome>().HasKey(x => x.Id);
            builder.Entity<ImageHome>().Property(x => x.Id)
                                       .ValueGeneratedOnAdd()
                                       .UseIdentityColumn(1, 1);
            builder.Entity<ImageHome>().HasOne(x => x.HomeFile).WithMany(x => x.ImageHomes).HasForeignKey(x => x.HomeFileId);


            builder.Entity<HomeDirection>().HasKey(x => x.Id);
            builder.Entity<HomeDirection>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            
            builder.Entity<City>().HasKey(x => x.Id);
            builder.Entity<City>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<City>().HasOne(x => x.Province).WithMany(x => x.Cities).HasForeignKey(x => x.ProvinceId);

            
            builder.Entity<TypeOfDocument>().HasKey(x => x.Id);
            builder.Entity<TypeOfDocument>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);


            builder.Entity<CategoryFacilities>().HasKey(x => x.Id);
            builder.Entity<CategoryFacilities>().Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);


            builder.Entity<Facilities>().HasKey(x => x.Id);
            builder.Entity<Facilities>().Property(x => x.Id)
                                        .ValueGeneratedOnAdd()
                                        .UseIdentityColumn(1, 1);
            builder.Entity<Facilities>().HasOne(x => x.CategoryFacilities).WithMany(x => x.Facilities)
                .HasForeignKey(x => x.CategoryFacilityId);


            builder.Entity<UserRegion>().HasKey(x => x.Id);
            builder.Entity<UserRegion>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<UserRegion>().HasOne(x => x.RealEstate_User).WithMany(x => x.UserRegions).HasForeignKey(x => x.UserId);
            builder.Entity<UserRegion>().HasOne(x => x.Region).WithMany(x => x.UserRegions).HasForeignKey(x => x.RegionId);


            builder.Entity<RealEstate>().HasKey(x => x.Id);
            builder.Entity<RealEstate>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<RealEstate>().HasOne(x => x.RealEstate_User).WithMany(x => x.RealEstates).HasForeignKey(x => x.UserId);


            builder.Entity<RealEstateAddress>().HasKey(x => x.Id);
            builder.Entity<RealEstateAddress>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<RealEstateAddress>().HasOne(x => x.RealEstate).WithMany(x => x.RealEstateAddresses).HasForeignKey(x => x.RealEstateId);

            builder.Entity<RealEstateTel>().HasKey(x => x.Id);
            builder.Entity<RealEstateTel>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<RealEstateTel>().HasOne(x => x.RealEstate).WithMany(x => x.RealEstateTels).HasForeignKey(x => x.RealEstateId);

            builder.Entity<Owner>().HasKey(x => x.Id);
            builder.Entity<Owner>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<Owner>().HasOne(x => x.RealEstate_User).WithMany(x => x.Owners).HasForeignKey(x => x.UserId);


            builder.Entity<OwnerTel>().HasKey(x => x.Id);
            builder.Entity<OwnerTel>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<OwnerTel>().HasOne(x => x.Owner).WithMany(x => x.OwnerTels).HasForeignKey(x => x.OwnerId);


            builder.Entity<Buyer>().HasKey(x => x.Id);
            builder.Entity<Buyer>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<Buyer>().HasOne(x => x.RealEstate_User).WithMany(x => x.Buyers).HasForeignKey(x => x.UserId);


            builder.Entity<BuyerTel>().HasKey(x => x.Id);
            builder.Entity<BuyerTel>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<BuyerTel>().HasOne(x => x.Buyer).WithMany(x => x.BuyerTels).HasForeignKey(x => x.BuyerId);


            builder.Entity<Investor>().HasKey(x => x.Id);
            builder.Entity<Investor>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<Investor>().HasOne(x => x.RealEstate_User).WithMany(x => x.Investors).HasForeignKey(x => x.UserId);

            builder.Entity<InvestorTel>().HasKey(x => x.Id);
            builder.Entity<InvestorTel>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<InvestorTel>().HasOne(x => x.Investor).WithMany(x => x.InvestorTels).HasForeignKey(x => x.InvestorId);

            builder.Entity<UserWorkArea>().HasKey(x => x.Id);
            builder.Entity<UserWorkArea>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<UserWorkArea>().HasOne(x => x.RealEstate_User).WithMany(x => x.UserWorkAreas).HasForeignKey(x => x.UserId);
        }
    }
}
