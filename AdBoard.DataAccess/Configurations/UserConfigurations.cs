using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdBoard.Infrastructure.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(x => x.LastName)
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(x => x.AvatarId)
               .IsRequired(false);

        builder.HasOne(x => x.Avatar)
               .WithOne()
               .HasForeignKey<UserEntity>(x => x.AvatarId);

        builder.HasMany(x => x.Stores)
               .WithOne(x => x.Seller)
               .HasForeignKey(x => x.SellerId);
    }
}