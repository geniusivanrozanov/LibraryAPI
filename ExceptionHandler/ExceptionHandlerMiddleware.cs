using System.Net;
using ExceptionHandler.Interfaces;
using ExceptionHandler.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ExceptionHandler;

public class ExceptionHandlerMiddleware
{
    private const string InternalServerErrorMessage = "Internal server error";
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    private readonly RequestDelegate _next;
    private readonly Dictionary<Type, HttpStatusCode> _statusCodes;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next, Dictionary<Type, HttpStatusCode> statusCodes)
    {
        _logger = logger;
        _next = next;
        _statusCodes = statusCodes;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            var errorDetails = GetErrorDetails(e);

            context.Response.StatusCode = (int)errorDetails.StatusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(errorDetails.ToString());
            
            _logger.LogError("Status code: {StatusCode}; Message: {Message}", (int)errorDetails.StatusCode, e.ToString());
        }
    }

    private ErrorDetails GetErrorDetails(Exception exception)
    {
        var statusCode = _statusCodes.ContainsKey(exception.GetType())
            ? _statusCodes[exception.GetType()]
            : HttpStatusCode.InternalServerError;

        var message = statusCode != HttpStatusCode.InternalServerError
            ? exception.Message
            : InternalServerErrorMessage;

        return new ErrorDetails()
        {
            StatusCode = statusCode,
            Message = message
        };
    }
}