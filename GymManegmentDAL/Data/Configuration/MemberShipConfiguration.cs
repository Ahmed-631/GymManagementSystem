using GymManegementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManegementDAL.Data.Configuration
{
    public class MemberShipConfiguration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
             builder.HasKey(x => new { x.MemberId , x.PlanId } );
            builder.Ignore(x => x.Id);
            builder.Property(x => x.CreatedAt)
                .HasColumnName("StartDate")
                .HasDefaultValueSql("GetDate()");

            builder.HasOne(sh => sh.Member)
             .WithMany(m => m.MemberPlans)
             .HasForeignKey(sh => sh.MemberId);


            builder.HasOne(sh => sh.Plan)
              .WithMany(m => m.PlanMembers)
              .HasForeignKey(sh => sh.PlanId);
        }
    }
}
