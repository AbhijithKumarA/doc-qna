using Pgvector;

namespace DocQnA.Api.Services.Interfaces;

public interface IEmbeddingService
{
    Task<Vector> GenerateEmbeddingAsync(string text);
}
