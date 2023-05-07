﻿using CarRentalApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalApi.Data.Mappings
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.UrlSlug)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.ImageUrl)
                .HasMaxLength(500);

            builder.Property(a => a.Email)
                .HasMaxLength(150);

            builder.Property(a => a.JoinedDate)
                .HasColumnType("datetime");

            builder.Property(a => a.Notes)
                .HasMaxLength(500);
        }
    }
}
