using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MoshaverAmlak.DataLayer.Entity
{
    public class RealEstate_Context : IdentityDbContext<IdentityUser, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public RealEstate_Context(DbContextOptions<RealEstate_Context> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Facilities>().HasKey(x => x.Id);
            builder.Entity<Facilities>().Property(x => x.Id)
                                        .ValueGeneratedOnAdd()
                                        .UseIdentityColumn(1, 1);

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
            builder.Entity<HomeFile>().HasOne(x => x.Room).WithMany(x => x.HomeFiles).HasForeignKey(x => x.RoomId);
            builder.Entity<HomeFile>().HasOne(x => x.BalconyPlace).WithMany(x => x.HomeFiles).HasForeignKey(x => x.BalconyPlaceId);
            builder.Entity<HomeFile>().HasOne(x => x.Neighbourhood).WithMany(x => x.HomeFiles).HasForeignKey(x => x.NeighbourhoodId);
            builder.Entity<HomeFile>().HasOne(x => x.Rebuilt).WithMany(x => x.HomeFiles).HasForeignKey(x => x.RebuiltId);
            builder.Entity<HomeFile>().HasOne(x => x.City).WithMany(x => x.HomeFiles).HasForeignKey(x => x.CityId);
            builder.Entity<HomeFile>().HasOne(x => x.TypeHome).WithMany(x => x.HomeFiles).HasForeignKey(x => x.TypeHomeId);
            builder.Entity<HomeFile>().HasOne(x => x.HomeDirection).WithMany(x => x.HomeFiles).HasForeignKey(x => x.HomeDirectionId);
            builder.Entity<HomeFile>().HasOne(x => x.Cupboard).WithMany(x => x.HomeFiles).HasForeignKey(x => x.CupboardId);
            builder.Entity<HomeFile>().HasOne(x => x.CWType).WithMany(x => x.HomeFiles).HasForeignKey(x => x.CWTypeId);
            builder.Entity<HomeFile>().HasOne(x => x.BuildingFacade).WithMany(x => x.HomeFiles).HasForeignKey(x => x.BuildingFacadeId);
            builder.Entity<HomeFile>().HasOne(x => x.FloorMaterial).WithMany(x => x.HomeFiles).HasForeignKey(x => x.FloorMaterialId);
            builder.Entity<HomeFile>().HasOne(x => x.DoorOpenerType).WithMany(x => x.HomeFiles).HasForeignKey(x => x.DoorOpenerTypeId);
            builder.Entity<HomeFile>().HasOne(x => x.AirConditioner).WithMany(x => x.HomeFiles).HasForeignKey(x => x.AirConditionerId);
            builder.Entity<HomeFile>().HasOne(x => x.HotWaterType).WithMany(x => x.HomeFiles).HasForeignKey(x => x.HotWaterTypeId);
            builder.Entity<HomeFile>().HasOne(x => x.HeatingType).WithMany(x => x.HomeFiles).HasForeignKey(x => x.HeatingTypeId);
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

            builder.Entity<Room>().HasKey(x => x.Id);
            builder.Entity<Room>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<BalconyPlace>().HasKey(x => x.Id);
            builder.Entity<BalconyPlace>().Property(x => x.Id)
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

            builder.Entity<TypeHome>().HasKey(x => x.Id);
            builder.Entity<TypeHome>().Property(x => x.Id)
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

            builder.Entity<Cupboard>().HasKey(x => x.Id);
            builder.Entity<Cupboard>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<City>().HasKey(x => x.Id);
            builder.Entity<City>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
            builder.Entity<City>().HasOne(x => x.Province).WithMany(x => x.Cities).HasForeignKey(x => x.ProvinceId);

            builder.Entity<CWType>().HasKey(x => x.Id);
            builder.Entity<CWType>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<BuildingFacade>().HasKey(x => x.Id);
            builder.Entity<BuildingFacade>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<FloorMaterial>().HasKey(x => x.Id);
            builder.Entity<FloorMaterial>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<DoorOpenerType>().HasKey(x => x.Id);
            builder.Entity<DoorOpenerType>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<AirConditioner>().HasKey(x => x.Id);
            builder.Entity<AirConditioner>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<FloorMaterial>().HasKey(x => x.Id);
            builder.Entity<FloorMaterial>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<HotWaterType>().HasKey(x => x.Id);
            builder.Entity<HotWaterType>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<HeatingType>().HasKey(x => x.Id);
            builder.Entity<HeatingType>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<HotWaterType>().HasKey(x => x.Id);
            builder.Entity<HotWaterType>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);

            builder.Entity<TypeOfDocument>().HasKey(x => x.Id);
            builder.Entity<TypeOfDocument>().Property(x => x.Id)
                                          .ValueGeneratedOnAdd()
                                          .UseIdentityColumn(1, 1);
        }
    }
}
