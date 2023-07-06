using System.Net;

namespace ExceptionHandler.Interfaces;

public interface IExceptionHandlerBuilder
{
    IExceptionHandlerBuilder AddExceptionStatusCode<T>(HttpStatusCode statusCode)
        where T : Exception;
}