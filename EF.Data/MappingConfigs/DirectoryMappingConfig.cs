using EF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.MappingConfigs
{
    public class DirectoryMappingConfig : IEntityTypeConfiguration<Directory>
    {
        public void Configure(EntityTypeBuilder<Directory> builder)
        {
            builder.ToTable("Directories", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_Directories")
                .IsClustered();

            builder.Property(x => x.Title)
                .HasMaxLength(32);

            builder.HasMany(x => x.Files)
                .WithOne(x => x.Directories)
                .HasForeignKey(x => x.DirectoryId)
                .HasConstraintName("FK_Files_Directories_DirectoryId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.DirectoryPermissions)
                .WithOne(x => x.Directory)
                .HasForeignKey(x => x.DirectoryId)
                .HasConstraintName("FK_DirectoryPermissions_Directory_DirectoryId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
