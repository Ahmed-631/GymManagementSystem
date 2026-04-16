using GymManagementBLL;
using GymManagementBLL.Service.Classes;
using GymManagementBLL.Service.Interfaces;
using GymManagementDAL.Data.DataSeeding;
using GymManagementDAL.Entities;
using GymManagementDAL.Entities.Repositories.Classes;
using GymManagementDAL.Entities.Repositories.Interfaces;
using GymManagementDAL.UnitOfWork;
using GymManegementDAL.Data.Context;
using GymManegementDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GymManegementPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
          

            builder.Services.AddDbContext<GymDbcontext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ISessionRepository, SessionRepository>();

            builder.Services.AddScoped<IAnalytiecsService,AnalyticesServicecs>();

            builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfiles()));

            builder.Services.AddScoped<IMemberService, MemberService>();
            builder.Services.AddScoped<ITrainerSarvice, TrainerSarvice >();
            builder.Services.AddScoped<IplanService, PlanService>();
            builder.Services.AddScoped<ISessionService, SessionService>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>( config => config.User.RequireUniqueEmail = true)
                .AddEntityFrameworkStores<GymDbcontext>();
            builder.Services.AddScoped<IAccountService, AccountService>(); 
           
           





            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

         


            var app = builder.Build();


            #region  DataSeeding 

            using var Scope = app.Services.CreateScope();
            var dbcontext = Scope.ServiceProvider.GetRequiredService<GymDbcontext>();
            var UserManger = Scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var RoleManger = Scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();




            GymDbcontextSeeding.DataSeeded(dbcontext);

            IdentityDbcontextSeeding.DataSeed(UserManger, RoleManger); 


            #endregion




            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            //app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");
               

            app.Run();
        }
    }
}
