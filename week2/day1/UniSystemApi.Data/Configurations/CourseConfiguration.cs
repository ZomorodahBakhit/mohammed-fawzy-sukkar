using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSystemApi.Data.Entities;

namespace UniSystemApi.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
            builder.Property(c => c.StartDate).IsRequired();
            builder.Property(c => c.EndDate).IsRequired();
        }
    }
}
