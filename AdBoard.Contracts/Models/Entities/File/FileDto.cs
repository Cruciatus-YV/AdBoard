namespace AdBoard.Contracts.Models.Entities.File;

/// <summary>
/// DTO для представления файла.
/// </summary>
public class FileDto
{
    /// <summary>
    /// Имя файла.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Содержимое файла в виде массива байтов.
    /// </summary>
    public byte[] Content { get; set; }

    /// <summary>
    /// Тип содержимого файла (например, "image/jpeg").
    /// </summary>
    public string ContentType { get; set; }
}
