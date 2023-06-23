using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.DAL.Entities.Configurations;

public class BookConfiguration : BaseEntityConfiguration<Book, Guid>
{
    public const int ISBNMaxLength = 20;
    public const int NameMaxLength = 256;
    public const int DescriptionMaxLength = 1024;
    
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);

        builder.HasIndex(b => b.ISBN)
            .IsUnique();

        builder.HasIndex(b => b.Name)
            .IsUnique();
        
        builder.Property(b => b.ISBN)
            .HasMaxLength(ISBNMaxLength)
            .IsRequired();

        builder.Property(b => b.Name)
            .HasMaxLength(NameMaxLength)
            .IsRequired();

        builder.Property(b => b.Description)
            .HasMaxLength(DescriptionMaxLength);
    }
}