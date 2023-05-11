using System.Text.Json.Serialization;

namespace EcommerDiscountSystem.Dtos;

public class CategoryDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<ProductDto> Products { get; set; }
    public DiscountDto Discount { get; set; }
}