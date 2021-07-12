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
    public class ProductMappingConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_Product")
                .IsClustered();

            builder.Property(x => x.Name)
                .HasMaxLength(32)
                .IsUnicode();

            builder.Property(x => x.CreatedAt)
                .HasMaxLength(32);

            builder.Property(x => x.Price)
                .HasMaxLength(32);

            builder.Property(x => x.Status)
                .HasMaxLength(32);

            builder.HasOne(x => x.Merchant)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.MerchantId)
               .HasConstraintName("FK_Merchant_Products_MerchantId")
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}