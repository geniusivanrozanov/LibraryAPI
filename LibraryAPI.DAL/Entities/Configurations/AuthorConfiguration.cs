using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.DAL.Entities.Configurations;

public class AuthorConfiguration : BaseEntityConfiguration<Author, Guid>
{
    public const int FirstNameMaxLength = 64;
    public const int LastNameMaxLength = 64;
        
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        base.Configure(builder);

        builder.HasIndex(a => new
        {
            a.FirstName,
            a.LastName
        }).IsUnique();

        builder.Property(a => a.FirstName)
            .HasMaxLength(FirstNameMaxLength);

        builder.Property(a => a.LastName)
            .HasMaxLength(LastNameMaxLength);
    }
}