namespace LibraryAPI.BLL.DTOs.BookRent;

public class GetBookRentDto : BookRentDto
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
}