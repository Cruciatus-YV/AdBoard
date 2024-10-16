using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdBoard.Infrastructure.Configurations;

public class StoreConfigurations : IEntityTypeConfiguration<StoreEntity>
{
    public void Configure(EntityTypeBuilder<StoreEntity> builder)
    {
        builder.ToTable("Stores");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .IsRequired();

        builder.Property(x => x.IsDefault)
               .IsRequired();

        builder.Property(x => x.Status)
               .IsRequired();

        builder.Property(x => x.SellerId)
               .IsRequired();

        builder.Property(x => x.Description)
               .IsRequired(false);

        builder.Property(x => x.AvatarId)
               .IsRequired(false);

        builder.HasOne(x => x.Avatar)
               .WithOne()
               .HasForeignKey<StoreEntity>(x => x.AvatarId);

        builder.HasOne(x => x.Seller)
               .WithMany()
               .HasForeignKey(x => x.SellerId);

        builder.HasMany(x => x.Products)
               .WithOne(x => x.Store)
               .HasForeignKey(x => x.StoreId);
    }
}