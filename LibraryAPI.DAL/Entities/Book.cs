using LibraryAPI.DAL.Interfaces.Entities;

namespace LibraryAPI.DAL.Entities;

public class Book : IBaseEntity<Guid>
{
    public Guid Id { get; set; }

    public string ISBN { get; set; } = default!;

    public string Name { get; set; } = default!;
    
    public string? Description { get; set; }
    
    public virtual ICollection<Genre>? Genres { get; set; }

    public virtual ICollection<Author>? Authors { get; set; }
    
    public virtual ICollection<BookRent>? Rents { get; set; }
}