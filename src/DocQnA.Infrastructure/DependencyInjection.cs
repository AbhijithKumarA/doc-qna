using DocQnA.Application.Common;
using DocQnA.Application.Documents;
using DocQnA.Application.Embeddings;
using DocQnA.Infrastructure.AI.Ollama;
using DocQnA.Infrastructure.Documents;
using DocQnA.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DocQnA.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DocQnADbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                npgSqlOptions =>
                {
                    npgSqlOptions.UseVector();
                });
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();
        services.AddScoped<IEmbeddingService, OllamaEmbeddingService>();

        services.Configure<OllamaOptions>(configuration.GetSection("AiProviders:Ollama"));
        services.AddHttpClient<IOllamaClient, OllamaClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<OllamaOptions>>().Value;
            client.BaseAddress = new Uri(options.BaseUrl);
        });

        return services;
    }
}
