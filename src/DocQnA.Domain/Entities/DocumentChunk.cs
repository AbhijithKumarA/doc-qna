namespace DocQnA.Domain.Entities;

public class DocumentChunk
{
    public long Id { get; set; }

    public string Content { get; set; } = string.Empty;

    public float[] Embeddings { get; set; } = [];
}
