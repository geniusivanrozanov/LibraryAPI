using System.Net;
using ExceptionHandler.Interfaces;

namespace ExceptionHandler;

public class ExceptionHandlerBuilder : IExceptionHandlerBuilder
{
    private readonly Dictionary<Type, HttpStatusCode> _statusCodes;

    public ExceptionHandlerBuilder(Dictionary<Type, HttpStatusCode> statusCodes)
    {
        _statusCodes = statusCodes;
    }

    public IExceptionHandlerBuilder AddExceptionStatusCode<T>(HttpStatusCode statusCode) where T : Exception
    {
        if (_statusCodes.ContainsKey(typeof(T)))
        {
            throw new ArgumentException($"Status code for {typeof(T)} already registered.");
        }
        
        _statusCodes[typeof(T)] = statusCode;

        return this;
    }
}