using AdBoard.Domain.Base;

namespace AdBoard.Domain.Entities;

public class ProductImageEntity : BaseEntity<long>
{
    public long FileId { get; set; }

    public long ProductId { get; set; }
}
