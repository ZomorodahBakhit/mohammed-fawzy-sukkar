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
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.id);

            builder.HasOne(g => g.Assignment);
            builder.HasOne(g => g.Student).WithMany(u => u.Grades).HasForeignKey(g => g.studentId).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
