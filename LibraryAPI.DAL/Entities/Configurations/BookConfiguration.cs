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

        builder.HasData(new ()
            {
                Id = new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"),
                Name = "The Twelve Chairs",
                Description = "The Twelve Chairs is a classic satirical novel by the Soviet authors Ilf and Petrov, published in 1928. Its plot follows characters attempting to obtain jewelry hidden in a chair. A sequel was published in 1931. The novel has been adapted to other media, primarily film.",
                ISBN = "978-5-906947-13-0"
            },
            new ()
            {
                Id = new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"),
                Name = "The Hitchhiker's Guide to the Galaxy",
                Description = "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text adventure game, and 2005 feature film.",
                ISBN = "978-5-17-098748-1"
            },
            new ()
            {
                Id = new Guid("db60cfb8-c695-4424-93b2-16f399659560"),
                Name = "One-storied America",
                Description = "One-storied America is a 1937 book based on a published travelogue across the United States by two Soviet authors, Ilf and Petrov. The book, divided into eleven chapters and in the uninhibited humorous style typical of Ilf and Petrov, paints a multi-faceted picture of the US.",
                ISBN = "5-7516-0630-2"
            });

        builder
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity<Dictionary<string, object>>(
                je => je.HasData(
                    new
                    {
                        BooksId = new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"),
                        AuthorsId = new Guid("8512a27d-bcee-4ebe-8a81-f1118fa9907f")
                    },
                    new
                    {
                        BooksId = new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"),
                        AuthorsId = new Guid("90bb4ac3-913d-4969-b722-e2572e303266")
                    },
                    new
                    {
                        BooksId = new Guid("db60cfb8-c695-4424-93b2-16f399659560"),
                        AuthorsId = new Guid("8512a27d-bcee-4ebe-8a81-f1118fa9907f")
                    },
                    new
                    {
                        BooksId = new Guid("db60cfb8-c695-4424-93b2-16f399659560"),
                        AuthorsId = new Guid("90bb4ac3-913d-4969-b722-e2572e303266")
                    },
                    new
                    {
                        BooksId = new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"),
                        AuthorsId = new Guid("33ecf2d1-6a08-41b4-ae09-01931b0eaba3")
                    }));

        builder
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity<Dictionary<string, object>>(
                je => je.HasData(
                    new
                    {
                        BooksId = new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"),
                        GenresId = new Guid("cc24957c-10b9-4293-8fb8-cf57348d330d")
                    },
                    new
                    {
                        BooksId = new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"),
                        GenresId = new Guid("4205fb30-889b-4c8d-9846-bf3503431b0c")
                    },
                    new
                    {
                        BooksId = new Guid("acb8f011-1d42-4660-8565-b49fcf4982ca"),
                        GenresId = new Guid("7a3b1aaf-1dbd-4136-8fcc-97df1e539910")
                    },
                    new
                    {
                        BooksId = new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"),
                        GenresId = new Guid("cc24957c-10b9-4293-8fb8-cf57348d330d")
                    },
                    new
                    {
                        BooksId = new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"),
                        GenresId = new Guid("4205fb30-889b-4c8d-9846-bf3503431b0c")
                    },
                    new
                    {
                        BooksId = new Guid("664d355c-9a27-45af-ab4e-4a94f314367a"),
                        GenresId = new Guid("9284771e-b85d-4921-9d58-5c9aa91f8f5f")
                    },
                    new
                    {
                        BooksId = new Guid("db60cfb8-c695-4424-93b2-16f399659560"),
                        GenresId = new Guid("cc24957c-10b9-4293-8fb8-cf57348d330d")
                    },
                    new
                    {
                        BooksId = new Guid("db60cfb8-c695-4424-93b2-16f399659560"),
                        GenresId = new Guid("1264a07b-1bf4-4b65-bbc1-fc3e53cff87a")
                    }));
    }
}