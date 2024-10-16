using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

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
               .HasMaxLength(255);

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

        builder.HasMany(p => p.Images)               // Один продукт имеет много изображений
               .WithOne()                             // Убираем навигационное свойство, которое связывает FileEntity с ProductEntity
               .OnDelete(DeleteBehavior.Cascade);    // При удалении продукта удаляем и связанные изображения, если они есть
    }
}