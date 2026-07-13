using DocQnA.Application.Documents;
using DocQnA.Domain.Entities;
using DocQnA.Infrastructure.Persistence;

namespace DocQnA.Infrastructure.Documents;

public class DocumentRepository : IDocumentRepository
{
    private readonly DocQnADbContext _dbContext;

    public DocumentRepository(DocQnADbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddDocumentChunksAsync(
        List<DocumentChunk> documentChunk,
        CancellationToken cancellationToken)
    {
        await _dbContext.DocumentChunks.AddRangeAsync(
            documentChunk,
            cancellationToken);
    }
}
