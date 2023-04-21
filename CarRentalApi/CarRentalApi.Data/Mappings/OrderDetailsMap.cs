using CarRentalApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Data.Mappings
{
    public class OrderDetailsMap : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("OrderDetails");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Car)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.CarId)
                .HasConstraintName("Fk_OrderDetails_Cars")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrdersId)
                .HasConstraintName("Fk_OrderDetails_Order")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Number)
                .HasDefaultValue(0);

            builder.Property(x => x.Price);
            builder.Property(x => x.TotalMoney);
        }
    }
}
