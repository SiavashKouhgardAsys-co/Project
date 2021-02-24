using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoshaverAmlak.Core.Repository.Repository.Class;
using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Class;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;

namespace MoshaverAmlak
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSession(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.IdleTimeout = TimeSpan.FromMilliseconds(20);
            });



            services.AddDbContext<RealEstate_Context>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefualtConnection")));



            services.AddIdentity<RealEstate_User, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredUniqueChars = 0;

                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            }).AddEntityFrameworkStores<RealEstate_Context>().AddDefaultTokenProviders();

            services.AddScoped<IdentityErrorDescriber>();

            //Contex
            services.AddTransient<RealEstate_Context>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //Repositories
            services.AddScoped<IFacilitiesRepository, FacilitiesRepository>();
            services.AddScoped<IFileTypeRepository , FileTypeRepository>();
            services.AddScoped<ICategoryFacilitiesRepository, CategoryFacilitiesRepository>();
            services.AddScoped<IHomeDirectionRepository, HomeDirectionRepository>();
            services.AddScoped<IHomeFileTypeRepository, HomeFileTypeRepository>();
            services.AddScoped<INeighbourhoodRepository, NeighbourhoodRepositroy>();
            services.AddScoped<IRebuiltRepository, RebuiltRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ITypeOfDocumentRepository, TypeOfDocumentRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ICityRepository, CityRepository>();

            //Services
            services.AddScoped<IHomeFileTypeService, HomeFileTypeService>();
            services.AddScoped<IFileTypeService, FileTypeService>();
            services.AddScoped<IHomeDirectionService, HomeDirectionService>();
            services.AddScoped<INeighbourhoodService, NeighbourhoodService>();
            services.AddScoped<ICategoryFacilitiesService, CategoryFacilitiesService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IRebuiltService, RebuiltService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    //pattern: "{area=user}/{controller=HomeFile}/{action=Index}/{id?}"
                  );
            });
        }
    }
}
