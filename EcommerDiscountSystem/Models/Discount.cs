namespace EcommerDiscountSystem.Models;

public class Discount
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Rate { get; set; }
    public List<Category> Categories { get; set; }
    public Discount(string name, decimal rate, List<Category> categories)
    {
        Name = name;
        Rate = rate;
        Categories = categories;
    }
}