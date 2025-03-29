using Market.Domain.Common;

namespace Market.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;
} 