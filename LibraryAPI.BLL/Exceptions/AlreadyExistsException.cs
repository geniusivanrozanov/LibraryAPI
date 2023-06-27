namespace LibraryAPI.BLL.Exceptions;

public class AlreadyExistsException : Exception
{
    public AlreadyExistsException()
    {
        
    }

    public AlreadyExistsException(string message) : base(message)
    {
        
    }
}