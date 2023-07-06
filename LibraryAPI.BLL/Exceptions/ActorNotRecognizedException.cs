namespace LibraryAPI.BLL.Exceptions;

public class ActorNotRecognizedException : Exception
{
    public ActorNotRecognizedException()
    {
        
    }

    public ActorNotRecognizedException(string message) : base(message)
    {
        
    }
}