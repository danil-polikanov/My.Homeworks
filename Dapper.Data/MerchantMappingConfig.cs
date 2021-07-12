using Dapper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dapper.Data
{
    public class MerchantMappingConfig : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.ToTable("Merchant", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_Merchant")
                .IsClustered();

            builder.Property(x => x.Name)
                .HasMaxLength(32)
                .IsUnicode();

            builder.Property(x => x.CreatedAt)
                .HasMaxLength(32);

            builder.HasOne(x => x.User)
               .WithOne(x => x.Merchant)
               .HasForeignKey<Merchant>(x => x.UserId)
               .HasConstraintName("FK_User_Merchant_UserId")
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Country)
               .WithMany(x => x.Merchants)
               .HasForeignKey(x => x.CountryId)
               .HasConstraintName("FK_Country_Merchants_CountryId")
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
