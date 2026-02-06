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
    public class TrainerConfiguration : GymUserConfiguration<Trainer> , IEntityTypeConfiguration<Trainer>

    {

        public new void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.Property(m => m.CreatedAt)
            .HasColumnName("HireDate")
            .HasDefaultValueSql("GETDATE()");

            builder.ToTable("Trainers");
            builder.HasKey(t => t.Id);


            base.Configure(builder);
        }
    }
}
