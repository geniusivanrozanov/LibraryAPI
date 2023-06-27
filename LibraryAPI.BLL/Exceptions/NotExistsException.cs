namespace LibraryAPI.BLL.Exceptions;

public class NotExistsException : Exception
{
    public NotExistsException()
    {
        
    }

    public NotExistsException(string message) : base(message)
    {
        
    }
}