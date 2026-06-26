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
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.id);
            builder.Property(a => a.title).IsRequired();
            builder.Property(a => a.description).HasColumnType("TEXT");
            builder.Property(a => a.weight).IsRequired();
            builder.Property(a => a.maxGrade).IsRequired();
            builder.Property(a => a.dueDate).IsRequired().HasColumnType("date");
            builder.HasOne(a => a.Course).WithMany(c => c.Assignments).HasForeignKey(a => a.courseId).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
