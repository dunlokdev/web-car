using CarRentalApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalApi.Data.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(c => c.PostedDate)
                .HasColumnType("datetime");
            builder.Property(c => c.IsApproved)
                .HasDefaultValue(false);
            builder.HasOne(c => c.Car)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.CarId)
                .HasConstraintName("FK_Comments_Cars")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
