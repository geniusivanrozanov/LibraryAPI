using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.DAL.Entities.Configurations;

public class BookRentConfiguration : BaseEntityConfiguration<BookRent, Guid>
{
    public override void Configure(EntityTypeBuilder<BookRent> builder)
    {
        base.Configure(builder);
    }
}