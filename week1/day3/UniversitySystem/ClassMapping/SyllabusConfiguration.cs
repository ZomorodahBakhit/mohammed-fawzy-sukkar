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
    public class SyllabusConfiguration : IEntityTypeConfiguration<Syllabus>
    {
        public void Configure(EntityTypeBuilder<Syllabus> builder)
        {
            builder.HasKey(s => s.id);
            builder.Property(s => s.description).IsRequired();
            builder.Property(s => s.description).HasColumnType("text");
            builder.HasMany(s => s.Courses);
        }
    }
}
