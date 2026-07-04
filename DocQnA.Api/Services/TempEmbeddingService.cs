using DocQnA.Api.Services.Interfaces;
using Pgvector;

namespace DocQnA.Api.Services;

public class TempEmbeddingService : IEmbeddingService
{
    private static readonly Vector DogCluster = new(
        Enumerable.Repeat(1.0f, 384).ToArray());

    private static readonly Vector VehicleCluster = new(
        Enumerable.Repeat(9.0f, 384).ToArray());

    public TempEmbeddingService()
    {
    }

    public async Task<Vector> GenerateEmbeddingAsync(string text)
    {
        text = text.ToLowerInvariant();

        if (text.Contains("dog") ||
            text.Contains("puppy") ||
            text.Contains("canine"))
        {
            return DogCluster;
        }

        if (text.Contains("car") ||
            text.Contains("truck") ||
            text.Contains("vehicle"))
        {
            return VehicleCluster;
        }

        // Default cluster
        return new Vector(Enumerable.Repeat(5.0f, 384).ToArray());
    }
}
