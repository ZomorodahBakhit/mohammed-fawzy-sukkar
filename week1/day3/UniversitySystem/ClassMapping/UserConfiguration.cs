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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.id);

            builder.Property(u => u.userName).IsRequired().HasMaxLength(64);
            builder.Property(u => u.firstName).IsRequired().HasMaxLength(64);
            builder.Property(u => u.lastName).IsRequired().HasMaxLength(64);
            builder.Property(u => u.phoneNumber).IsRequired().HasMaxLength(16);
            builder.Property(u => u.role).IsRequired().HasMaxLength(32);

            builder.Property(u => u.email).IsRequired().HasMaxLength(128);
            builder.HasMany(u => u.Grades);
            builder.HasIndex(u => u.email).IsUnique();
        }
    }
}
