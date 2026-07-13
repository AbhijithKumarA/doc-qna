using System;
using System.Collections.Generic;
using System.Text;

namespace DocQnA.Infrastructure.AI.Ollama;

public class EmbedRequest
{
    public string Model { get; set; } = default!;

    public List<string> Input { get; set; } = default!;
}
