using AdBoard.AppServices.Contexts.File.Repositories;
using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Models.Entities.File;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace AdBoard.AppServices.Contexts.File.Services;

/// <summary>
/// Сервис для работы с файлами.
/// </summary>
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
    public static async Task<List<FileEntity>> CalculateFiles(IFormFileCollection files, CancellationToken cancellationToken)
    {
        var fileEntities = new List<FileEntity>();

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
                Name = file.FileName, 
                Length = content.Length,
            };

            fileEntities.Add(entity);
        }

        return fileEntities;
    }

    public async Task<IEnumerable<FileEntity>> UploadListAsync(IFormFileCollection files, CancellationToken cancellationToken)
    {
        var entities = await CalculateFiles(files, cancellationToken);
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
