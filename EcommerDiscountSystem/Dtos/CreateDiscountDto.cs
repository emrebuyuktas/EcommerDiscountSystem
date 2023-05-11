namespace EcommerDiscountSystem.Dtos;

public class CreateDiscountDto
{
    public List<string> CategoryId { get; set; }
    public string DiscountHeader { get; set; }
    public string DiscountDetails { get; set; }
    public decimal Rate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}