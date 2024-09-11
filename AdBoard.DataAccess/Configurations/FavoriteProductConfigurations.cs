using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdBoard.DataAccess.Configurations;

public class FavoriteProductConfigurations : IEntityTypeConfiguration<FavoriteProductEntity>
{
    public void Configure(EntityTypeBuilder<FavoriteProductEntity> builder)
    {
        builder.ToTable("FavoriteProducts");

        builder.HasKey(x => x.Id);

        builder.Property(c => c.UserId)
            .IsRequired();

        builder.Property(c => c.ProductId)
            .IsRequired();


        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId);
    }
}
