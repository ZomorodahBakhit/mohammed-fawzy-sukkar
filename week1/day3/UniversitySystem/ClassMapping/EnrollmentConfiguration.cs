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
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => e.id);

            builder.HasOne(e => e.Student)
                   .WithMany(u => u.Enrollments)
                   .HasForeignKey(e => e.studentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Course)
                   .WithMany(c => c.Enrollments)
                   .HasForeignKey(e => e.courseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}