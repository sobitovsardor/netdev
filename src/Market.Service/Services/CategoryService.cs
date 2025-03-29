using Market.DataAccess.Data;
using Market.DataAccess.Repositories;
using Market.Domain.Entities;
using Market.Service.DTOs.CategoryDtos;
using Market.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.Service.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;
    private readonly IGenericRepository<Category> _categoryRepository;

    public CategoryService(AppDbContext context, IGenericRepository<Category> categoryRepository)
    {
        _context = context;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryViewDto>> GetAllAsync()
    {
        var categories = await _context.Categories
            .Where(c => !c.IsDeleted)
            .ToListAsync();

        return categories.Select(c => new CategoryViewDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            ImageUrl = c.ImageUrl,
            ProductCount = c.Products.Count,
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt
        });
    }

    public async Task<CategoryViewDto?> GetByIdAsync(long id)
    {
        var category = await _context.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

        if (category == null) return null;

        return new CategoryViewDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            ImageUrl = category.ImageUrl,
            ProductCount = category.Products.Count,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt
        };
    }

    public async Task<CategoryViewDto> CreateAsync(CategoryCreateDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl
        };

        await _categoryRepository.AddAsync(category);

        var createdCategory = await _context.Categories
            .Include(c => c.Products)
            .FirstAsync(c => c.Id == category.Id);

        return new CategoryViewDto
        {
            Id = createdCategory.Id,
            Name = createdCategory.Name,
            Description = createdCategory.Description,
            ImageUrl = createdCategory.ImageUrl,
            ProductCount = createdCategory.Products.Count,
            CreatedAt = createdCategory.CreatedAt,
            UpdatedAt = createdCategory.UpdatedAt
        };
    }

    public async Task<CategoryViewDto> UpdateAsync(long id, CategoryUpdateDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null) throw new Exception("Category not found");

        category.Name = dto.Name;
        category.Description = dto.Description;
        category.ImageUrl = dto.ImageUrl;

        await _categoryRepository.UpdateAsync(category);

        var updatedCategory = await _context.Categories
            .Include(c => c.Products)
            .FirstAsync(c => c.Id == id);

        return new CategoryViewDto
        {
            Id = updatedCategory.Id,
            Name = updatedCategory.Name,
            Description = updatedCategory.Description,
            ImageUrl = updatedCategory.ImageUrl,
            ProductCount = updatedCategory.Products.Count,
            CreatedAt = updatedCategory.CreatedAt,
            UpdatedAt = updatedCategory.UpdatedAt
        };
    }

    public async Task DeleteAsync(long id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
} 