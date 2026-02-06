using GymManegementDAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManegementDAL.Data.Configuration
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessiones"); 
             builder.HasKey(x => x.Id);
            builder.ToTable( s => {
                s.HasCheckConstraint("SessonCapacityCheck", "Capacity  between 1 and 25");
                s.HasCheckConstraint("SessonEndDateCheck", "  EndDate > StartDate");
            });
            builder.HasOne(s => s.Category)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.CategoryId);

            builder.HasOne(s => s.Trainer)
                .WithMany(t => t.sessions)
                .HasForeignKey( s => s.TrainerId);
        }
    }
}
