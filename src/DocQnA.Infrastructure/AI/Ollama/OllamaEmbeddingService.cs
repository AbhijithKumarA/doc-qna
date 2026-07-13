using DocQnA.Application.Embeddings;

using Microsoft.Extensions.Options;

namespace DocQnA.Infrastructure.AI.Ollama;

public class OllamaEmbeddingService : IEmbeddingService
{
    private readonly IOllamaClient _ollamaClient;

    private readonly IOptions<OllamaOptions> _options;

    public OllamaEmbeddingService(
        IOllamaClient ollamaClient,
        IOptions<OllamaOptions> options)
    {
        _ollamaClient = ollamaClient;
        _options = options;
    }

    public async Task<List<float[]>> GenerateEmbeddingAsync(
        IReadOnlyCollection<string> text,
        CancellationToken cancellationToken)
    {
        EmbedRequest payload = new()
        {
            Model = _options.Value.EmbeddingModel,
            Input = text.ToList()
        };

        var response = await _ollamaClient.EmbedAsync(
            payload,
            cancellationToken);

        return response.Embeddings.ToList();
    }
}
