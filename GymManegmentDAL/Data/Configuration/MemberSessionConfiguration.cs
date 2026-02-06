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
    public class MemberSessionConfiguration : IEntityTypeConfiguration<MemberSession>
    {
        public void Configure(EntityTypeBuilder<MemberSession> builder)
        {
             builder.HasKey(x => new { x.MemberId , x.SessionId });

            builder.Ignore(x => x.Id);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("BookingDay")
                .HasDefaultValueSql("GetDate()");

            builder.HasOne(s => s.Member)
               .WithMany(s => s.MemberSession)
               .HasForeignKey(s => s.MemberId);


            builder.HasOne(s => s.Session)
             .WithMany(s => s.MemberSession)
             .HasForeignKey(s => s.SessionId);

        }
    }
}
