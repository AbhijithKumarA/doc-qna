using DocQnA.Application.Common;
using DocQnA.Application.Embeddings;
using DocQnA.Domain.Entities;

namespace DocQnA.Application.Documents;

public class DocumentService : IDocumentService
{
    private readonly IEmbeddingService _embeddingService;
    
    private readonly IDocumentRepository _documentRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DocumentService(
        IEmbeddingService embeddingService,
        IUnitOfWork unitOfWork,
        IDocumentRepository documentRepository)
    {
        _embeddingService = embeddingService;
        _unitOfWork = unitOfWork;
        _documentRepository = documentRepository;
    }

    public async Task CreateDocumentChunksAsync(
        IReadOnlyCollection<string> text,
        CancellationToken cancellationToken)
    {
        // Generate the embedding for the document text
        var embeddings = await _embeddingService.GenerateEmbeddingAsync(text, cancellationToken);

        if (embeddings.Count != text.Count)
        {
            throw new InvalidOperationException("The number of embeddings does not match the number of text chunks.");
        }

        var documentChunks = text.Select((content, index) => new DocumentChunk
        {
            Content = content,
            Embeddings = embeddings[index]
        }).ToList();

        await _documentRepository.AddDocumentChunksAsync(documentChunks, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
