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

            builder.Entity<ImageHome>().HasKey(x => x.Id);
            builder.Entity<ImageHome>().Property(x => x.Id)
                                       .ValueGeneratedOnAdd()
                                       .UseIdentityColumn(1, 1);
            builder.Entity<ImageHome>().HasOne(x => x.HomeFile).WithMany(x => x.ImageHomes).HasForeignKey(x => x.HomeFileId);
        }
    }
}
