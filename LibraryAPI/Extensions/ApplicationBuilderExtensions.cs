using System.Net;
using ExceptionHandler.Extensions;
using LibraryAPI.BLL.Exceptions;

namespace LibraryAPI.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder ConfigureExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
        app.UseExceptionHandlerMiddleware()
            .AddExceptionStatusCode<AlreadyExistsException>(HttpStatusCode.Conflict)
            .AddExceptionStatusCode<IdentifierMismatchException>(HttpStatusCode.BadRequest)
            .AddExceptionStatusCode<NotExistsException>(HttpStatusCode.NotFound)
            .AddExceptionStatusCode<ValidationException>(HttpStatusCode.BadRequest)
            .AddExceptionStatusCode<RegistrationFailedException>(HttpStatusCode.Conflict)
            .AddExceptionStatusCode<LoginFailedException>(HttpStatusCode.BadRequest);
        
        return app;
    }
}