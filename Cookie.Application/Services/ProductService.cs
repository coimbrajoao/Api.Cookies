using Cookie.Application.DTOs.ProductDto;
using Cookie.Application.Exceptions;
using Cookie.Application.Interfaces;
using Cookie.Application.Mapper;
using Cookie.Domain.Interfaces;
using Cookie.Domain.Pagination;

namespace Cookie.Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<ProductGetDto> GetByIdAsync(int id)
    {
        var product =  await productRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new NotFoundException("Produto não foi encontrado");;
        }
        var productGet = ProductMapper.MapToProductGetDto(product);

        return productGet;
    }

    public async Task<PagedList<ProductGetDto>> GetAllAsync(int pageNumber, int pageSize)
    {
        var list  = await productRepository.GetAllAsync(pageNumber,pageSize);
        
        var productDto = list
            .Select(ProductMapper.MapToProductGetDto)
            .ToList();
        
        return new PagedList<ProductGetDto>(productDto, list.CurrentPage, list.PageSize,  list.TotalCount);
    }

    public async Task<ProductGetDto> AddAsync(ProductRequestDto productGetDto)
    {
        var productPost = ProductMapper.MapToProduct(productGetDto);
        await productRepository.AddAsync(productPost);
        var productGet = ProductMapper.MapToProductGetDto(productPost);
        return productGet;
    }

    public async Task<ProductGetDto> UpdateAsync(int id,ProductUpdateDto productUpdateDto)
    {
        var productUpdate = await productRepository.GetByIdAsync(id);
        if (productUpdate == null)
        {
            throw new NotFoundException("Produto não foi encontrado");
        }

        if (!string.IsNullOrWhiteSpace(productUpdateDto.Name))
           productUpdate.UpdateName(productUpdateDto.Name);

        if (!string.IsNullOrWhiteSpace(productUpdateDto.Description))
            productUpdate.UpdateDescription(productUpdateDto.Description);
        
        if (!string.IsNullOrWhiteSpace(productUpdateDto.Flavor))
            productUpdate.UpdateFlavor(productUpdateDto.Flavor);
        
        
        if (productUpdateDto.Price.HasValue)
        {
            productUpdate.SetPrice(productUpdateDto.Price.Value);
        }
        
        await productRepository.UpdateAsync(productUpdate);
        
        return ProductMapper.MapToProductGetDto(productUpdate);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await productRepository.DeleteAsync(id);
        return product;
    }
}