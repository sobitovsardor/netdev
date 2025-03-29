namespace Market.Service.DTOs.ProductDtos;

public class ProductUpdateDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
    public long CategoryId { get; set; }
} 