namespace EcommerDiscountSystem.Models;

public class Discount
{
    public string Id { get; set; }
    public string DiscountHeader { get; set; }
    public string DiscountDetails { get; set; }
    public decimal Rate { get; set; }
    public List<Category> Categories { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public Discount(string header, decimal rate, DateTime startDate, DateTime endDate, List<Category> categories, string discountDetails)
    {
        DiscountHeader = header;
        Rate = rate;
        StartDate = startDate;
        EndDate = endDate;
        Categories = categories;
        DiscountDetails = discountDetails;
    }
    public Discount()
    {
        
    }
}