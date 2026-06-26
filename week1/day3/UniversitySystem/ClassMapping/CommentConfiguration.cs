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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.createdDate).IsRequired();
            builder.Property(c => c.content).HasColumnType("TEXT");

            builder.HasOne(c => c.Assignment).WithMany(a => a.Comments).HasForeignKey(c => c.assignmentId).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasOne(c => c.User).WithMany(u => u.Comments).HasForeignKey(c => c.userId).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
