using DocQnA.Application.Documents;
using DocQnA.Application.Embeddings;
using Microsoft.Extensions.DependencyInjection;

namespace DocQnA.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDocumentService, DocumentService>();
        return services;
    }
}
