namespace DocQnA.Infrastructure.AI.Ollama;

public interface IOllamaClient
{
    Task<EmbedResponse> EmbedAsync<T>(
        T payload,
        CancellationToken cancellationToken);
}
