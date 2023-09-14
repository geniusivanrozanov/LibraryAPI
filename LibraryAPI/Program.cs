using LibraryAPI.BLL.Extensions;
using LibraryAPI.DAL.Extensions;
using LibraryAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddClaimsPrincipal();

builder.Services.AddDataAccessLayer(configuration);
builder.Services.AddBusinessLogicLayer(configuration);

builder.Services.AddAuthorization();
builder.Services.ConfigureAuthentication(configuration);

builder.Services.InitializeDatabase(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();