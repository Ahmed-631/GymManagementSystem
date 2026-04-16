using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using GymManegementDAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GymManagementDAL.Entities;

namespace GymManegementDAL.Data.Context
{
    public class GymDbcontext :IdentityDbContext<ApplicationUser>
    {

        public GymDbcontext (DbContextOptions<GymDbcontext> options) : base(options) 
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=GymManagement;Trusted_Connection=True;TrustServerCertificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<ApplicationUser>(Eb =>
            {
                Eb.Property(x => x.FirstName)
                  .HasColumnType("varchar")
                  .HasMaxLength(50);
                Eb.Property(x => x.LastName)
                  .HasColumnType("varchar")
                   .HasMaxLength(50);


            }
        

             ); 
           
        }

        public DbSet<HealthRecord> HealthRecord { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Member> Members { set; get; }
        public   DbSet<Plan> Plans    { set; get; }
        public DbSet<Trainer> Trainers { set; get; }
        public DbSet<MemberSession> MemberSessions  { set; get; }
        public DbSet<MemberShip> MemberShips { set; get; }
        public DbSet<Session> Sessions { set; get; }




    }
}
