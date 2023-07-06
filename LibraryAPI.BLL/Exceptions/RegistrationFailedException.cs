namespace LibraryAPI.BLL.Exceptions;

public class RegistrationFailedException : Exception
{
    public RegistrationFailedException()
    {
        
    }

    public RegistrationFailedException(string message) : base(message)
    {
        
    }
}