using Pgvector;

namespace DocQnA.Api.Models;

public class DocumentChunk
{
    public long Id { get; set; }

    public string Content { get; set; } = string.Empty;

    public Vector Embeddings { get; set; } = null!;
}
