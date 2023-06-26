namespace LibraryAPI.BLL.DTOs.Genre;

public class GetGenreDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
}