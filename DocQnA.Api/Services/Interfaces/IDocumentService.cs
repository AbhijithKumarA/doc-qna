namespace DocQnA.Api.Services.Interfaces;

public interface IDocumentService
{
    Task EmbedAndSaveDocument(string text);
}
