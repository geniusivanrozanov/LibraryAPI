namespace LibraryAPI.BLL.DTOs.Book;

public class GetBookDto : BookDto
{
    public Guid Id { get; set; }

    public string Genres { get; set; } = default!;

    public string Authors { get; set; } = default!;
}