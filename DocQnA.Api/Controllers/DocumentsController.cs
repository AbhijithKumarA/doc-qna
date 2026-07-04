using DocQnA.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocQnA.Api.Controllers;

[Route("api/documents")]
[ApiController]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentService _documentService;

    public DocumentsController(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    [HttpPost("save")]
    public async Task<IActionResult> SaveDocument([FromBody] string text)
    {
        // Call the DocumentService to save the document
        await _documentService.EmbedAndSaveDocument(text);
        return Ok();
    }
}
