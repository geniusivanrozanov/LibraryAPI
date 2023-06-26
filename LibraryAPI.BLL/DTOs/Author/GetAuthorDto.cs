namespace LibraryAPI.BLL.DTOs.Author;

public class GetAuthorDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
}