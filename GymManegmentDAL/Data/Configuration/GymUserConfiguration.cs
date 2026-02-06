using GymManegementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManegementDAL.Data.Configuration 
           



{
    public class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> U)
        {
          
            U.Property(u => u.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            U.Property(u => u.Email).HasColumnType("varchar")
               .HasMaxLength(100).IsRequired(); 
             

            U.Property(u => u.Phone).HasColumnType("varchar")
               .HasMaxLength(11)
               .IsRequired()
               ;

            U.ToTable( u =>
            { 
                u.HasCheckConstraint("GymUserValidEmail", " Email Like    '_%@_%._%'");
                u.HasCheckConstraint("GymUserValidPhone", " Phone Like   '01[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'"); 
            }
          
            );
            U.HasIndex(u => u.Email).IsUnique();
            U.HasIndex(u => u.Phone).IsUnique();


            U.OwnsOne(u =>
            u.Address,
            a =>
            {
                a.Property(a => a.Street).HasColumnType("varchar").HasMaxLength(30).HasColumnName("Street");
                a.Property(a => a.City).HasColumnType("varchar").HasMaxLength(30).HasColumnName("City");
                a.Property(a => a.BuildingNumber).HasColumnName("BuildingNumber");
            });  






    }
    }
}
