﻿namespace LibraryAPI.BLL.DTOs.BookRent;

public class BookRentDto
{
    public DateTime TakingDate { get; set; }
    
    public DateTime ReturnDate { get; set; }
    
    public Guid BookId { get; set; }
}