namespace EcommerDiscountSystem.Models;

public class Discount
{
    public string Id { get; set; }
    public string DiscountName { get; set; }
    public decimal Rate { get; set; }
    public List<Category> Categories { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public Discount(string name, decimal rate, DateTime startDate, DateTime endDate, List<Category> categories)
    {
        DiscountName = name;
        Rate = rate;
        StartDate = startDate;
        EndDate = endDate;
        Categories = categories;
    }
}