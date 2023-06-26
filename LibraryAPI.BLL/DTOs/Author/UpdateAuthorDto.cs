namespace LibraryAPI.BLL.DTOs.Author;

public class UpdateAuthorDto
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
}