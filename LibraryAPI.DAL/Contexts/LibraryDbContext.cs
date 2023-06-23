using System.Reflection;
using LibraryAPI.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Contexts;

public class LibraryDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public DbSet<Book> Books { get; set; } = default!;

    public DbSet<Genre> Genres { get; set; } = default!;

    public DbSet<Author> Authors { get; set; } = default!;

    public DbSet<BookRent> BookRents { get; set; } = default!;

    public LibraryDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}