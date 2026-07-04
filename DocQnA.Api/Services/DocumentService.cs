using DocQnA.Api.Data;
using DocQnA.Api.Models;
using DocQnA.Api.Services.Interfaces;

namespace DocQnA.Api.Services;

public class DocumentService : IDocumentService
{
    private readonly IEmbeddingService _embeddingService;
    private readonly DocQnADbContext _dbContext;

    public DocumentService(IEmbeddingService embeddingService, DocQnADbContext dbContext)
    {
        _embeddingService = embeddingService;
        _dbContext = dbContext;
    }

    public async Task EmbedAndSaveDocument(string text)
    {
        // Generate the embedding for the document text
        var embedding = await _embeddingService.GenerateEmbeddingAsync(text);

        DocumentChunk documentChunk = new DocumentChunk
        {
            Content = text,
            Embeddings = embedding
        };

        _dbContext.DocumentChunks.Add(documentChunk);
        await _dbContext.SaveChangesAsync();
    }
}
