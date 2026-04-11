using System.ComponentModel.DataAnnotations;

namespace Cookie.Application.DTOs;

public class ProductRequestDto
{
    [Required (ErrorMessage = "Nome do produto é Obrigatorio.")]
    [MaxLength(50, ErrorMessage = "Nome deve ter no maximo 50 caracteres.")]
    public string Name { get; private set; }
    
    [Required (ErrorMessage = "A Descrição é Obrigatorio.")]
    [MaxLength(500, ErrorMessage = "Descrição deve ter no maximo 50, caracteres.")]
    public string Description { get; private set; }
    
    [Required (ErrorMessage = "O Preço e Obrigatorio.")]
    public decimal Price { get; private set; }
    
    [Required (ErrorMessage = "Sabor é Obrigatorio.")]
    [MaxLength(50, ErrorMessage = "Sabor ter no maximo 50 caracteres.")]
    public string Flavor { get; private set; }
    
    
}