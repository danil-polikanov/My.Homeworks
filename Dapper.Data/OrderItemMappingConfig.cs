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

    public class OrderItemMappingConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_OrdersItem")
                .IsClustered();

            builder.Property(x => x.Quantity)
                .HasMaxLength(32);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .HasConstraintName("FK_Order_OrderItems_OrderId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Product)
               .WithMany(x => x.OrderItems)
               .HasForeignKey(x => x.ProductId)
               .HasConstraintName("FK_Product_OrderItems_ProductId")
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
