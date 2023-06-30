using LibraryAPI.DAL.Interfaces.Entities;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.DAL.Entities;

public class BookRent : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    
    public DateTime TakingDate { get; set; }
    
    public DateTime ReturnDate { get; set; }
    
    public Guid BookId { get; set; }
    public virtual Book? Book { get; set; }
    
    public Guid UserId { get; set; }
    public virtual IdentityUser<Guid>? User { get; set; }
}