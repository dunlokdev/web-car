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
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {

            /*
                public int Id { get; set; }
                public int ModelId { get; set; }
                public string Name { get; set; }
                public double Price { get; set; }
                public int Discount { get; set; }
                public string Thumbnail { get; set; }
                public string Description { get; set; }
                public string UrlSlug { get; set; }
                public bool IsActived { get; set; }
                public DateTime CreatedAt { get; set; }
                public DateTime UpdatedAt { get; set; }
                public IList<Galery> Galery { get; set; }
                public Model Model { get; set; }
                public OrderDetails OrderDetails { get; set; }
             */
            builder.ToTable("Cars");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Discount)
                .HasDefaultValue(0);

            builder.Property(x => x.Thumbnail)
                .HasMaxLength(500);

            builder.Property(x => x.ShortDescripton)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(x => x.UrlSlug)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.IsActived)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.Wattage)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.Torque)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.SpeedUp)
                .IsRequired()
                .HasDefaultValue(0);


            builder.Property(x => x.MaxSpeed)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.Consume)
                .HasDefaultValue(0);

            builder.Property(x => x.Emission)
                .HasDefaultValue(0);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("datetime");

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("datetime");

            builder.HasOne(x => x.Model)
                .WithMany(x => x.CarList)
                .HasForeignKey(x => x.ModelId)
                .HasConstraintName("Fk_Cars_Models")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
