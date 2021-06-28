using EF.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.MappingConfigs
{
    public class UserMappingConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_Users")
                .IsClustered();

            builder.Property(x => x.UserName)
                .HasMaxLength(32)
                .IsUnicode();

            builder.Property(x => x.Email)
                .HasMaxLength(32)
                .IsUnicode();

            builder.Property(x => x.PasswordHash)
                .HasMaxLength(32);

            builder.HasMany(x => x.DirectoryPermissions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_DirectoryPermissions_Users_UserId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.FilePermissions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_FilePermissions_Users_UserId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
