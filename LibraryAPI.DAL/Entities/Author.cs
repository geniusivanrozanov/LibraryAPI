using LibraryAPI.DAL.Interfaces.Entities;

namespace LibraryAPI.DAL.Entities;

public class Author : IBaseEntity<Guid>
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
    
    public virtual ICollection<Book>? Books { get; set; }
}