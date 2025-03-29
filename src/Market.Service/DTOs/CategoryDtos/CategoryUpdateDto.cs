namespace Market.Service.DTOs.CategoryDtos;

public class CategoryUpdateDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ImageUrl { get; set; }
} 