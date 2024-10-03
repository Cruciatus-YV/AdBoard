using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdBoard.Infrastructure.Configurations;

public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItemEntity>
{
    public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProductId)
               .IsRequired();

        builder.Property(x => x.OrderId)
               .IsRequired();

        builder.Property(x => x.OrderPrice)
               .IsRequired(false);

        builder.Property(x => x.Count)
               .IsRequired();

        builder.Property(x => x.MeasurementUnit)
               .IsRequired();

        builder.Property(x => x.Status)
               .IsRequired(false);

        builder.Property(x => x.IsDeleted)
               .IsRequired();

        builder.HasOne(x => x.Order)
               .WithMany(x => x.OrderItems)
               .HasForeignKey(x => x.OrderId);

        builder.HasOne(x => x.Product)
               .WithMany()
               .HasForeignKey(x => x.ProductId);
    }
}