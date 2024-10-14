using AdBoard.AppServices.Contexts.File.Repositories;
using AdBoard.AppServices.Exceptions;
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

    public async Task<long> UploadAsync(IFormFile file, CancellationToken cancellationToken)
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

        var result = await _fileRepository.InsertAsync(entity, cancellationToken);

        return result;
    }

    public async Task<IEnumerable<FileEntity>> UploadListAsync(IFormFileCollection files, CancellationToken cancellationToken)
    {
        var entities = new List<FileEntity>();
        foreach (var file in files) 
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

            entities.Add(entity);   
        }

        var result = await _fileRepository.InsertListAsync(entities, cancellationToken);

        return result; 
    }


    public async Task<FileDto> DownloadAsync(long id, CancellationToken cancellationToken)
    {
        var file = await _fileRepository.GetByIdAsync(id, cancellationToken);

        if (file == null)
        {
            throw new NotFoundException("Файл не найден");
        }

        return new FileDto
        {
            Content = file.Content,
            ContentType = file.ContentType,
            Name = file.Name,
        };
    }

    public async Task<FileInfoDto> GetFileInfoAsync(long id, CancellationToken cancellationToken)
    {
        var file = await _fileRepository.GetByIdAsync(id, cancellationToken);

        if (file == null)
        {
            throw new NotFoundException("Файл не найден");
        }

        return new FileInfoDto
        {
            Id = file.Id,
            Name = file.Name,
            Length = file.Length,
            CreatedAt = file.CreatedAt,
            ContentType = file.ContentType,
        };
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken)
    {
        await _fileRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task DeleteListAsync(IReadOnlyCollection<long> ids, CancellationToken cancellationToken)
    {
        await _fileRepository.DeleteListAsync(ids, cancellationToken);
    }
}
