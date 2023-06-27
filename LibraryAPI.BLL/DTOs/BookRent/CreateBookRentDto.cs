namespace LibraryAPI.BLL.DTOs.BookRent;

public class CreateBookRentDto
{
    public DateTime TakingDate { get; set; }
    
    public DateTime ReturnDate { get; set; }
    
    public Guid BookId { get; set; }

    public Guid UserId { get; set; }
}