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
    public class MemberConfiguration : GymUserConfiguration<Member>  ,  IEntityTypeConfiguration<Member>
    {
        public new void Configure(EntityTypeBuilder<Member> builder)
        {   
            builder.Property(m => m.CreatedAt)
                .HasColumnName("JoinDate")
                .HasDefaultValueSql("GETDATE()");
            builder.ToTable("Members");
            builder.HasKey(m => m.Id);


            base.Configure(builder);
        }
    }
}
