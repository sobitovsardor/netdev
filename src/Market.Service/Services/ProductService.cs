using Market.DataAccess.Data;
using Market.DataAccess.Repositories;
using Market.Domain.Entities;
using Market.Service.DTOs.ProductDtos;
using Market.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.Service.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    private readonly IGenericRepository<Product> _productRepository;

    public ProductService(AppDbContext context, IGenericRepository<Product> productRepository)
    {
        _context = context;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductViewDto>> GetAllAsync()
    {
        var products = await _context.Products
            .Include(p => p.Category)
            .Where(p => !p.IsDeleted)
            .ToListAsync();

        return products.Select(p => new ProductViewDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            ImageUrl = p.ImageUrl,
            CategoryName = p.Category.Name,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt
        });
    }

    public async Task<ProductViewDto?> GetByIdAsync(long id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

        if (product == null) return null;

        return new ProductViewDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            ImageUrl = product.ImageUrl,
            CategoryName = product.Category.Name,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
    }

    public async Task<ProductViewDto> CreateAsync(ProductCreateDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            StockQuantity = dto.StockQuantity,
            ImageUrl = dto.ImageUrl,
            CategoryId = dto.CategoryId
        };

        await _productRepository.AddAsync(product);

        var createdProduct = await _context.Products
            .Include(p => p.Category)
            .FirstAsync(p => p.Id == product.Id);

        return new ProductViewDto
        {
            Id = createdProduct.Id,
            Name = createdProduct.Name,
            Description = createdProduct.Description,
            Price = createdProduct.Price,
            StockQuantity = createdProduct.StockQuantity,
            ImageUrl = createdProduct.ImageUrl,
            CategoryName = createdProduct.Category.Name,
            CreatedAt = createdProduct.CreatedAt,
            UpdatedAt = createdProduct.UpdatedAt
        };
    }

    public async Task<ProductViewDto> UpdateAsync(long id, ProductUpdateDto dto)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) throw new Exception("Product not found");

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.StockQuantity = dto.StockQuantity;
        product.ImageUrl = dto.ImageUrl;
        product.CategoryId = dto.CategoryId;

        await _productRepository.UpdateAsync(product);

        var updatedProduct = await _context.Products
            .Include(p => p.Category)
            .FirstAsync(p => p.Id == id);

        return new ProductViewDto
        {
            Id = updatedProduct.Id,
            Name = updatedProduct.Name,
            Description = updatedProduct.Description,
            Price = updatedProduct.Price,
            StockQuantity = updatedProduct.StockQuantity,
            ImageUrl = updatedProduct.ImageUrl,
            CategoryName = updatedProduct.Category.Name,
            CreatedAt = updatedProduct.CreatedAt,
            UpdatedAt = updatedProduct.UpdatedAt
        };
    }

    public async Task DeleteAsync(long id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProductViewDto>> GetByCategoryIdAsync(long categoryId)
    {
        var products = await _context.Products
            .Include(p => p.Category)
            .Where(p => p.CategoryId == categoryId && !p.IsDeleted)
            .ToListAsync();

        return products.Select(p => new ProductViewDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            ImageUrl = p.ImageUrl,
            CategoryName = p.Category.Name,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt
        });
    }
} 