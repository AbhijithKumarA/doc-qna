using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DocQnA.Infrastructure.AI.Ollama;

public class EmbedResponse
{
    [JsonPropertyName("embeddings")]
    public float[][] Embeddings { get; set; } = default!;
}
