using Cookie.Application.DTOs;
using Cookie.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cookie.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
      _productService = productService;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateProduct(ProductRequestDto productRequestDto)
    {
        var createdProduct = await _productService.AddAsync(productRequestDto);
        if (createdProduct == null)
        {
            return BadRequest("Não foi possivel criar o produto");
        }
        
        return Ok(createdProduct);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProduct(ProductUpdateDTO productUpdateDto)
    {
        var updateProduct = await _productService.UpdateAsync(productUpdateDto);
        if (updateProduct == null)
        {
            return NotFound("Não foi possivel encontrar o produto");
        }
        
        return Ok(updateProduct);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult> GetProductById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound("Não foi possivel encontrar o produto");
        }
        return Ok(product);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteProductById(int id)
    {
        var product = await _productService.DeleteAsync(id);
        if (product == null)
        {
            return BadRequest("Ocorreu um erro ao excluir o produto");
        }
        return Ok(new { Message = "Produto excluido com sucesso"});
    }

    [HttpGet]
    public async Task<ActionResult> GetProductsAsync()
    {
        var products = await _productService.GetAllAsync();
        if (products == null)
        {
            return NotFound("Não foi possivel apresentar o produtos");
        }
        return Ok(products);
    }
    
}