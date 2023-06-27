namespace LibraryAPI.BLL.DTOs.Book;

public class BookDto
{
    public string ISBN { get; set; } = default!;

    public string Name { get; set; } = default!;
    
    public string? Description { get; set; }
}