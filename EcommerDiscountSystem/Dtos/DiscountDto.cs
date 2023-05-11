using System.Text.Json.Serialization;

namespace EcommerDiscountSystem.Dtos;

public class DiscountDto
{
    public string Id { get; set; }
    public string DiscountHeader { get; set; }
    public string DiscountDetails { get; set; }
    public decimal Rate { get; set; }
    public List<CategoryDto> Categories { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}