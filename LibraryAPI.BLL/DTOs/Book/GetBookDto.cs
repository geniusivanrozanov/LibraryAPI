namespace LibraryAPI.BLL.DTOs.Book;

public class GetBookDto
{
    public Guid Id { get; set; }

    public string ISBN { get; set; } = default!;

    public string Name { get; set; } = default!;
    
    public string? Description { get; set; }

    public string Genres { get; set; } = default!;

    public string Authors { get; set; } = default!;
}