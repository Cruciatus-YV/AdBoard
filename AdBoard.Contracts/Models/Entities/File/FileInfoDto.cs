namespace AdBoard.Contracts.Models.Entities.File;

/// <summary>
/// DTO для представления информации о файле.
/// </summary>
public class FileInfoDto
{
    /// <summary>
    /// Уникальный идентификатор файла.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя файла.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Длина файла в байтах.
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// Дата и время создания файла.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
