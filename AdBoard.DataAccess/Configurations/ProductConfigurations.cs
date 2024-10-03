using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdBoard.Infrastructure.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
               .IsRequired();

        builder.Property(x => x.Price)
               .IsRequired();

        builder.Property(x => x.StoreId)
               .IsRequired();

        builder.Property(x => x.Count)
               .IsRequired();

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(x => x.CategoryId)
               .IsRequired();

        builder.Property(x => x.Description)
               .IsRequired(false);

        builder.HasMany(x => x.Feedback)
               .WithOne(x => x.Product)
               .HasForeignKey(x => x.ProductId);

        builder.HasOne(x => x.Store)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.StoreId);

        builder.HasOne(x => x.Category)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.CategoryId);
    }
}