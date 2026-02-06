using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using GymManegementDAL.Entities;

namespace GymManegementDAL.Data.Context
{
    public class GymDbcontext : DbContext
    {

        public GymDbcontext (DbContextOptions<GymDbcontext> options) : base(options)     { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=GymManagement;Trusted_Connection=True;TrustServerCertificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           
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
