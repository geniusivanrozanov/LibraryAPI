namespace LibraryAPI.BLL.DTOs.Genre;

public class UpdateGenreDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
}