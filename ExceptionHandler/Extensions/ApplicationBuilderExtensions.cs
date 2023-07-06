using System.Net;
using ExceptionHandler.Interfaces;
using Microsoft.AspNetCore.Builder;

namespace ExceptionHandler.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IExceptionHandlerBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
        var statusCodes = new Dictionary<Type, HttpStatusCode>();
        app.UseMiddleware<ExceptionHandlerMiddleware>(statusCodes);

        return new ExceptionHandlerBuilder(statusCodes);
    }
}