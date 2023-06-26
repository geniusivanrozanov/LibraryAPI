namespace LibraryAPI.BLL.DTOs.Book;

public class CreateBookDto
{
    public string ISBN { get; set; } = default!;

    public string Name { get; set; } = default!;
    
    public string? Description { get; set; }
}