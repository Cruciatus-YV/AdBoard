using AdBoard.AppServices.Contexts.File.Services;
using AdBoard.Contracts.Models.Entities.File;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AdBoard.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер для работы с файлами (загрузка, скачивание, информация).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : AdBoardBaseController
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// Загрузка файла в базу данных.
        /// </summary>
        /// <param name="file">Файл для загрузки.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Результат операции загрузки файла с информацией о файле.</returns>
        /// <response code="201">Файл был успешно загружен.</response>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
        {
            var result = await _fileService.UploadAsync(file, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created, result);
        }

        /// <summary>
        /// Скачивание файла по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор файла.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Файл с содержимым.</returns>
        [HttpGet("{id:long}")]
        [Authorize]
        [ProducesResponseType(typeof(File), 200)]
        public async Task<IActionResult> Download(long id, CancellationToken cancellationToken)
        {
            var result = await _fileService.DownloadAsync(id, cancellationToken);

            Response.ContentLength = result.Content.Length;

            return File(result.Content, result.ContentType, result.Name);
        }

        /// <summary>
        /// Получение информации о файле по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор файла.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Статус-код 200 OK с информацией о файле.</returns>
        /// <response code="200">Данные о файле были успешно получены.</response>
        [HttpGet("info/{id}")]
        [ProducesResponseType(typeof(FileInfoDto), 200)]
        public async Task<IActionResult> GetFileInfo(long id, CancellationToken cancellationToken)
        {
            var result = await _fileService.GetFileInfoAsync(id, cancellationToken);
            return Ok(result);
        }
    }
}
