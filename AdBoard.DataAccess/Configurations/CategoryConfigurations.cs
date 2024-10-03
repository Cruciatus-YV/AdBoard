using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdBoard.Infrastructure.Configurations;

public class CategoryConfigurations : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(category => category.Id);

        builder.Property(category => category.Name)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(category => category.Approved)
               .IsRequired();

        builder.Property(category => category.ParentId)
               .IsRequired(false);

        builder.Property(category => category.IsDeleted)
               .IsRequired();

        builder.HasMany(category => category.Products)
               .WithOne(product => product.Category)
               .HasForeignKey(product => product.CategoryId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(category => category.ChildCategories)
               .WithOne()
               .HasForeignKey(category => category.ParentId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(category => category.ParentId);
    }
}