using AdBoard.Contracts.Models.Entities.File;
using Microsoft.AspNetCore.Http;

namespace AdBoard.AppServices.Contexts.File.Services;

/// <summary>
/// Интерфейс для сервиса работы с файлами. Предоставляет методы для загрузки, скачивания и удаления файлов.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Загружает файл в базу.
    /// </summary>
    /// <param name="file">Файл для загрузки.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Идентификатор загруженного файла.</returns>
    Task<long> UploadAsync(IFormFile file, CancellationToken cancellationToken);

    /// <summary>
    /// Загружает список файлов.
    /// </summary>
    /// <param name="files">Коллекция файлов для загрузки.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Список загруженных файлов.</returns>
    Task<IEnumerable<FileEntity>> UploadListAsync(IFormFileCollection files, CancellationToken cancellationToken);

    /// <summary>
    /// Скачивает файл по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Объект, содержащий информацию о файле.</returns>
    Task<FileDto> DownloadAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Получает информацию о файле по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Объект с информацией о файле.</returns>
    Task<FileInfoDto> GetFileInfoAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет файл по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор файла, который нужно удалить.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    Task DeleteAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет список файлов по их идентификаторам.
    /// </summary>
    /// <param name="ids">Список идентификаторов файлов, которые нужно удалить.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    Task DeleteListAsync(IReadOnlyCollection<long> ids, CancellationToken cancellationToken);
}
