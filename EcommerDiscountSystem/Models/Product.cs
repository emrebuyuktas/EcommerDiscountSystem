namespace EcommerDiscountSystem.Models;

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public string CategoryId { get; set; }
    public Product(string name, decimal price, Category category)
    {
        Name = name;
        Price = price;
        Category = category;
    }
    public Product()
    {
        
    }
}