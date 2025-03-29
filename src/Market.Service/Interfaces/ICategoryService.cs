using Market.Service.DTOs.CategoryDtos;

namespace Market.Service.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryViewDto>> GetAllAsync();
    Task<CategoryViewDto?> GetByIdAsync(long id);
    Task<CategoryViewDto> CreateAsync(CategoryCreateDto dto);
    Task<CategoryViewDto> UpdateAsync(long id, CategoryUpdateDto dto);
    Task DeleteAsync(long id);
} 