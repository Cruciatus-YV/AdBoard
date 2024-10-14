using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdBoard.DataAccess.Configurations;

class ProductImageConfiguration : IEntityTypeConfiguration<ProductImageEntity>
{
    public void Configure(EntityTypeBuilder<ProductImageEntity> builder)
    {
        builder.ToTable("ProductImages");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.ProductId)
               .IsRequired();

        builder.Property(p => p.FileId)
               .IsRequired();
    }
}
