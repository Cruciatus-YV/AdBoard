using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdBoard.DataAccess.Configurations;

public class CategoryConfigurations : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.ParentId)
            .IsRequired(false);

        builder.Property(c => c.IsDeleted)
            .IsRequired();

        builder.HasMany(c => c.ChildCategories)
               .WithOne()
               .HasForeignKey(c => c.ParentId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(c => c.ParentId);
    }
}