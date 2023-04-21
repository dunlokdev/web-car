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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fullname)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Address)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Note)
                .HasMaxLength(1000);

            builder.Property(x => x.OrderDate)
                .HasColumnType("datetime");

            builder.Property(x => x.Status)
                .HasDefaultValue(false);

            builder.Property(x => x.TotalMoney);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("Fk_Orders_Users")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
