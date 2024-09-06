using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdBoard.DataAccess.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(x => x.Id);
        //builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
        //builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
        //builder.HasMany(x => x.Stores).WithOne(x => x.Seller).HasForeignKey(x => x.SellerId);
    }
}
