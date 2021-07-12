using Dapper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Data
{
    public class UserMappingConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_User")
                .IsClustered();

            builder.Property(x => x.FullName)
                .HasMaxLength(32)
                .IsUnicode();

            builder.Property(x => x.Email)
                .HasMaxLength(32)
                .IsUnicode();

            builder.Property(x => x.Gender)
                .HasMaxLength(32).IsUnicode();

            builder.Property(x => x.DateOfBirth)
                .HasMaxLength(32);

            builder.Property(x => x.CreatedAt)
                .HasMaxLength(32);

            builder.HasOne(x => x.CountryCodes)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.CountryId)
                .HasConstraintName("FK_CountryCodes_Users_CountryId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
