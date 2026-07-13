namespace DocQnA.Application.Embeddings;

public interface IEmbeddingService
{
    Task<List<float[]>> GenerateEmbeddingAsync(
        IReadOnlyCollection<string> text,
        CancellationToken cancellationToken);
}
