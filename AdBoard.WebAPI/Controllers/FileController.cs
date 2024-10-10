using AdBoard.AppServices.Contexts.File.Services;
using AdBoard.Contracts.Models.Entities.File;
using Microsoft.AspNetCore.Mvc;

namespace AdBoard.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController : AdBoardBaseController
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
    {
        await _fileService.UploadAsync(file, cancellationToken);

        return Created();
    }

    [HttpGet("download/{id}")]
    public async Task<IActionResult> Download(long id, CancellationToken cancellationToken)
    {
        var result = await _fileService.DownloadAsync(id, cancellationToken);

        Response.ContentLength = result.Content.Length;

        return File(result.Content, result.ContentType, result.Name);
    }

    [HttpGet("{id}/info")]
    public async Task<IActionResult> GetFileInfo(long id, CancellationToken cancellationToken)
    {
        var result = await _fileService.GetFileInfoAsync(id, cancellationToken);
        return Ok(result);
    }
}
