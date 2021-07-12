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
    public class OrderMappingConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_Order")
                .IsClustered();

            builder.Property(x => x.Status)
                .HasMaxLength(32)
                .IsUnicode();

            builder.Property(x => x.CreatedAt)
                .HasMaxLength(32);

            builder.Property(x => x.OrderJson)
                .HasMaxLength(300).IsUnicode();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserID)
                .HasConstraintName("FK_User_Orders_UserID")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
