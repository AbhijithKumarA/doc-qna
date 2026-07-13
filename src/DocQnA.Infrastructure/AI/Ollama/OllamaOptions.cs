using System;
using System.Collections.Generic;
using System.Text;

namespace DocQnA.Infrastructure.AI.Ollama;

public class OllamaOptions
{
    public string BaseUrl { get; set; } = default!;

    public string EmbeddingModel { get; set; } = default!;
}
