using System.Net.Http.Json;

namespace DocQnA.Infrastructure.AI.Ollama;

public class OllamaClient : IOllamaClient
{
    private readonly HttpClient _httpClient;

    public OllamaClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<EmbedResponse> EmbedAsync<T>(
        T payload,
        CancellationToken cancellationToken)
    {
        string endpoint = "api/embed";

        var response = await _httpClient.PostAsJsonAsync(
            endpoint,
            payload,
            cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<EmbedResponse>(cancellationToken)
            ?? throw new InvalidOperationException("Invalid Ollama repsonse."); ;
    }
}
