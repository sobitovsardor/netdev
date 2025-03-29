using Market.Service.DTOs.ProductDtos;

namespace Market.Service.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductViewDto>> GetAllAsync();
    Task<ProductViewDto?> GetByIdAsync(long id);
    Task<ProductViewDto> CreateAsync(ProductCreateDto dto);
    Task<ProductViewDto> UpdateAsync(long id, ProductUpdateDto dto);
    Task DeleteAsync(long id);
    Task<IEnumerable<ProductViewDto>> GetByCategoryIdAsync(long categoryId);
} 