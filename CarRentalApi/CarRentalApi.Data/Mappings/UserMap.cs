using CarRentalApi.Core.Contracts;
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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fullname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(x => x.Address)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(32)
                .IsRequired();

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName("Fk_Users_Roles")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
