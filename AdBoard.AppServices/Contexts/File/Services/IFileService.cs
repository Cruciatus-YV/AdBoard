using AdBoard.Contracts.Models.Entities.File;
using Microsoft.AspNetCore.Http;

namespace AdBoard.AppServices.Contexts.File.Services;

public interface IFileService
{
    Task<long> UploadAsync(IFormFile file, CancellationToken cancellationToken);

    Task<FileDto> DownloadAsync(long id, CancellationToken cancellationToken);

    Task<FileInfoDto> GetFileInfoAsync(long id, CancellationToken cancellationToken);
}
