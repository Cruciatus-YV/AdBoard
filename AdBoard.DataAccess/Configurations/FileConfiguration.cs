using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdBoard.DataAccess.Configurations;

public class FileConfiguration : IEntityTypeConfiguration<FileEntity>
{
    public void Configure(EntityTypeBuilder<FileEntity> builder)
    {
        builder.ToTable("Files");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(x => x.ContentType)
               .HasMaxLength(255)
               .IsRequired();
    }
}
