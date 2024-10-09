using AdBoard.AppServices.Contexts.Feedback.Repositories;
using AdBoard.AppServices.Contexts.File.Repositories;
using AdBoard.Contracts.Models.Entities.File;
using Microsoft.AspNetCore.Http;

namespace AdBoard.AppServices.Contexts.File.Services;

public class FileService : IFileService
{
    private readonly IFileRepository _fileRepository;

    public FileService(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public  async Task<long> UploadAsync(IFormFile file, CancellationToken cancellationToken)
    {
        using var ms = new MemoryStream();
        await file.CopyToAsync(ms, cancellationToken);
        var content = ms.ToArray();

        var entity = new FileEntity
        {
            CreatedAt = DateTime.UtcNow,
            Content = content,
            ContentType = file.ContentType,
            Name = file.Name,
            Length = content.Length,
        };

        return await _fileRepository.InsertAsync(entity, cancellationToken);
    }
}
