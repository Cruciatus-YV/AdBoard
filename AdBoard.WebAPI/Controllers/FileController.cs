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
}
