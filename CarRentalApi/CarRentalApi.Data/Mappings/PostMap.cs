using CarRentalApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalApi.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.ShortDescription)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(p => p.UrlSlug)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Meta)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(1000);

            builder.Property(p => p.ViewCount)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(p => p.Published)
             .HasDefaultValue(false)
             .IsRequired();

            builder.Property(p => p.PostedDate)
                .HasColumnType("datetime");

            builder.Property(p => p.ModifiedDate)
                .HasColumnType("datetime");

            builder.HasOne(p => p.Author)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.AuthorId)
                .HasConstraintName("Fk_Posts_Authors")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
