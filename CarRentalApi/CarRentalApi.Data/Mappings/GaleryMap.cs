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
    public class GaleryMap : IEntityTypeConfiguration<Galery>
    {
        public void Configure(EntityTypeBuilder<Galery> builder)
        {
            builder.ToTable("Galeries");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Thumbnail)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(x => x.Car)
                .WithMany(x => x.Galery)
                .HasForeignKey(x => x.CarId)
                .HasConstraintName("Fk_Galeries_Cars")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
