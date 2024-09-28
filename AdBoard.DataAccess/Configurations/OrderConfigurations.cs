using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdBoard.DataAccess.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ConsumerId)
               .IsRequired();

        builder.Property(x => x.StoreId)
               .IsRequired();

        builder.Property(x => x.Status)
               .IsRequired();

        builder.HasOne(x => x.Consumer)
               .WithMany()
               .HasForeignKey(x => x.ConsumerId);

        builder.HasOne(x => x.Store)
               .WithMany()
               .HasForeignKey(x => x.StoreId);

        builder.HasMany(x => x.OrderItems)
               .WithOne(x => x.Order)
               .HasForeignKey(x => x.OrderId);
    }
}