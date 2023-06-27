namespace LibraryAPI.BLL.Exceptions;

public class IdentifierMismatchException : Exception
{
    public IdentifierMismatchException()
    {
        
    }

    public IdentifierMismatchException(string message) : base(message)
    {
        
    }
}