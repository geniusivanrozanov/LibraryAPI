namespace LibraryAPI.BLL.DTOs.Book;

public class UpdateBookDto
{
    public Guid Id { get; set; }

    public string ISBN { get; set; } = default!;

    public string Name { get; set; } = default!;
    
    public string? Description { get; set; }
}