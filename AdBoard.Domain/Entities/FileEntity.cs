using AdBoard.Domain.Base;

/// <summary>
/// Сущностьфайла.
/// </summary>
public class FileEntity : CreatableEntity<long>
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
    /// Тип содержимого файла (например, "image/png", "application/pdf").
    /// </summary>
    public string ContentType { get; set; }

    /// <summary>
    /// Длина содержимого файла в байтах.
    /// </summary>
    public int Length { get; set; }
}
