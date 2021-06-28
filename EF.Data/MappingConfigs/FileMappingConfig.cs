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
    public class FileMappingConfig : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("Files", "sch");

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.Property(x => x.Title)
                .HasMaxLength(32);

            builder.Property(x => x.Extension)
                .HasMaxLength(32);

            builder.Property(x => x.Size)
                .HasMaxLength(32);

            builder.HasOne(x => x.Directories)
                .WithMany(x=>x.Files)
                .HasForeignKey(x => x.DirectoryId)
                .HasConstraintName("FK_Directory_File_DirectoryId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.FilePermissions)
                .WithOne(x => x.File)
                .HasForeignKey(x => x.FileId)
                .HasConstraintName("FK_FilePermissions_File_FileId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
