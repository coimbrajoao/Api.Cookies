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
        if (createdProduct == null)
        {
            return BadRequest("Não foi possivel criar o produto");
        }
        
        return Ok(createdProduct);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> UpdateProduct(int id,ProductUpdateDto productUpdateDto)
    {
        var updateProduct = await productService.UpdateAsync(id,productUpdateDto);
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
        var product = await productService.GetByIdAsync(id);
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
        var product = await productService.DeleteAsync(id);
        if (product == null)
        {
            return BadRequest("Ocorreu um erro ao excluir o produto");
        }
        return Ok(new { Message = "Produto excluido com sucesso"});
    }

    [HttpGet]
    public async Task<ActionResult> GetProductsAsync()
    {
        var products = await productService.GetAllAsync();
        if (products == null)
        {
            return NotFound("Não foi possivel apresentar o produtos");
        }
        return Ok(products);
    }
    
}