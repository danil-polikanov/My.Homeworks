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
    public class CountryCodeMappingConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_Country")
                .IsClustered();

            builder.Property(x => x.Name)
                .HasMaxLength(32)
                .IsUnicode();

            builder.Property(x => x.Country_Code)
           .HasMaxLength(32)
           .IsUnicode();

            
        }
    }
}
