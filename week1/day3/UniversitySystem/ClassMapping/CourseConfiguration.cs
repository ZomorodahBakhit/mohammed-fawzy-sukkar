using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Models;

namespace UniversitySystem.ClassMapping
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.name).IsRequired().HasMaxLength(100);
            builder.HasKey(c => c.id);
            builder.Property(c => c.startDate).IsRequired();
            builder.Property(c => c.endDate).IsRequired();
            builder.HasOne(c => c.teacher).WithMany(u => u.Courses).HasForeignKey(c => c.teacherId).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasOne(c => c.Syllabus).WithMany(s => s.Courses).HasForeignKey(c => c.syllabusId).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasMany(c => c.Assignments);
        }
    }
}
