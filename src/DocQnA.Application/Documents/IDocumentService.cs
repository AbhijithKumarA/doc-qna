namespace DocQnA.Application.Documents;

public interface IDocumentService
{
    Task CreateDocumentChunksAsync(
        IReadOnlyCollection<string> text,
        CancellationToken cancellationToken);
}
