using DocQnA.Domain.Entities;

namespace DocQnA.Application.Documents;

public interface IDocumentRepository
{
    Task AddDocumentChunksAsync(
        List<DocumentChunk> documentChunk,
        CancellationToken cancellationToken);
}
