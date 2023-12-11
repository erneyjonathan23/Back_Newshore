using OP.Prueba.Application;
using OP.Prueba.Identity;
using OP.Prueba.Persistence;
using OP.Prueba.Shared;
using OP.Prueba.WebAPI.Extensions;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

// Add services to the container.
builder.Services.AddApplicationLayer();
builder.Services.AddSharedInfraestructure(configuration);
builder.Services.AddPersistenceInfraestructure(configuration);
builder.Services.AddIdentityInfraestructure(configuration);
builder.Services.AddControllers();
builder.Services.AddApiVersioningExtension();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseErrorHandleMiddleware();

app.MapControllers();

app.Run();

namespace OP.Prueba.WebAPI
{
    [ExcludeFromCodeCoverage]
    public partial class Program { }
}