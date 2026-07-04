using DocQnA.Api.Data;
using DocQnA.Api.Services;
using DocQnA.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region Dependency Injection
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IEmbeddingService, TempEmbeddingService>();
#endregion

// Add DbContext with PostgreSQL and vector extension
builder.Services.AddDbContext<DocQnADbContext>(options =>
{
    options.UseNpgsql(
     builder.Configuration.GetConnectionString("DefaultConnection"),
     npgSqlOptions =>
     {
         npgSqlOptions.UseVector();
     });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
