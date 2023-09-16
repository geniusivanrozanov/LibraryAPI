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

        builder.HasData(
            new Genre
            {
                Id = new Guid("cc24957c-10b9-4293-8fb8-cf57348d330d"),
                Name = "Humor"
            },
            new Genre
            {
                Id = new Guid("4205fb30-889b-4c8d-9846-bf3503431b0c"),
                Name = "Novel"
            },
            new Genre
            {
                Id = new Guid("7a3b1aaf-1dbd-4136-8fcc-97df1e539910"),
                Name = "Fiction"
            },
            new Genre
            {
                Id = new Guid("9284771e-b85d-4921-9d58-5c9aa91f8f5f"),
                Name = "Sci-fy"
            },
            new Genre
            {
                Id = new Guid("1264a07b-1bf4-4b65-bbc1-fc3e53cff87a"),
                Name = "Adventure"
            });
    }
}