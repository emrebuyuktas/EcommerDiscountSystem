using Newtonsoft.Json;

namespace EcommerDiscountSystem.Dtos;

public class ProductDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public CategoryDto Category { get; set; }
    public decimal? DiscountRate { get; set; }
    public decimal? DiscountedPrice { get; set; }
}