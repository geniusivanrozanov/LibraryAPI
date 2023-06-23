using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.DAL.Entities.Configurations;

public class GenreConfiguration : BaseEntityConfiguration<Genre, Guid>
{
    public const int NameMaxLength = 256;
    public override void Configure(EntityTypeBuilder<Genre> builder)
    {
        base.Configure(builder);

        builder.HasIndex(g => g.Name)
            .IsUnique();
        
        builder.Property(g => g.Name)
            .HasMaxLength(NameMaxLength)
            .IsRequired();
    }
}