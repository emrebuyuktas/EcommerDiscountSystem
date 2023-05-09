namespace EcommerDiscountSystem.Models;

public class Category
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }
    public Discount Discount { get; set; }
    public string DiscountId { get; set; }
    public Category(string name)
    {
        Name = name;
    }
}