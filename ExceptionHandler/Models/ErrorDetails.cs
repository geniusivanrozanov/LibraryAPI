using System.Net;
using System.Text.Json;

namespace ExceptionHandler.Models;

public record class ErrorDetails
{
    public HttpStatusCode StatusCode { get; set; }
    
    public string? Message { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}