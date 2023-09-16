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

        builder.HasData(
            new Author()
            {
                Id = new Guid("8512a27d-bcee-4ebe-8a81-f1118fa9907f"),
                FirstName = "Ilya",
                LastName = "Ilf"
            },
            new Author()
            {
                Id = new Guid("90bb4ac3-913d-4969-b722-e2572e303266"),
                FirstName = "Yevgeniy",
                LastName = "Petrov"
            },
            new Author()
            {
                Id = new Guid("33ecf2d1-6a08-41b4-ae09-01931b0eaba3"),
                FirstName = "Douglas",
                LastName = "Adams"
            });
    }
}