using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdBoard.DataAccess.Configurations;

public class FavoriteProductConfigurations : IEntityTypeConfiguration<FavoriteProductEntity>
{
    public void Configure(EntityTypeBuilder<FavoriteProductEntity> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
