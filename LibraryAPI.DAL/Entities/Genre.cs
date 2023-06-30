using LibraryAPI.DAL.Interfaces.Entities;

namespace LibraryAPI.DAL.Entities;

public class Genre : IBaseEntity<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    
    public virtual ICollection<Book>? Books { get; set; }
}