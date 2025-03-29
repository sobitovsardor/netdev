using Market.Domain.Common;

namespace Market.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
} 