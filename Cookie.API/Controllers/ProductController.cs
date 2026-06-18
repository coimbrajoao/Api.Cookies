using Cookie.API.Extensions;
using Cookie.API.Models;
using Cookie.Application.DTOs.ProductDto;
using Cookie.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cookie.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : Controller
{
    [HttpPost]
    public async Task<ActionResult> CreateProduct(ProductRequestDto productRequestDto)
    {
        var createdProduct = await productService.AddAsync(productRequestDto);
        return Ok(createdProduct);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> UpdateProduct(int id,ProductUpdateDto productUpdateDto)
    {
        var updateProduct = await productService.UpdateAsync(id,productUpdateDto);
        return Ok(updateProduct);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult> GetProductById(int id)
    {
        var product = await productService.GetByIdAsync(id);
        return Ok(product);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteProductById(int id)
    {
        var product = await productService.DeleteAsync(id);
        return Ok(new { Message = "Produto excluido com sucesso"});
    }

    [HttpGet]
    public async Task<ActionResult> GetProductsAsync([FromQuery]PaginationParams paginationParams)
    {
        var products = await productService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
        
        Response.AddPaginationHeader(
            new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, products.TotalPages, products.TotalCount));
        
        return Ok(products);
    }
    
}