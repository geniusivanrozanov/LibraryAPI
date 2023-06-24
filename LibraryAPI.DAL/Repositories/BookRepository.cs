﻿using LibraryAPI.DAL.Contexts;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Repositories;

public class BookRepository : Repository<Book, Guid, LibraryDbContext>, IBookRepository
{
    public BookRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        var books = await Get()
            .ToListAsync();

        return books;
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId)
    {
        var books = await Get(b => b.Authors.Any(a => a.Id.Equals(authorId)))
            .ToListAsync();

        return books;
    }

    public async Task<IEnumerable<Book>> GetBooksByGenreIdAsync(Guid genreId)
    {
        var books = await Get(b => b.Genres.Any(a => a.Id.Equals(genreId)))
            .ToListAsync();

        return books;
    }

    public async Task<Book?> GetBookByIdAsync(Guid id)
    {
        var book = await Get(b => b.Id.Equals(id))
            .SingleOrDefaultAsync();

        return book;
    }

    public async Task<Book?> GetBookByISBNAsync(string isbn)
    {
        var book = await Get(b => b.ISBN == isbn)
            .SingleOrDefaultAsync();

        return book;
    }

    public void CreateBook(Book book)
    {
        Create(book);
    }

    public void UpdateBook(Book book)
    {
        Update(book);
    }

    public void DeleteBook(Book book)
    {
        Delete(book);
    }
}