namespace EcommerDiscountSystem.Helpers;

public static class DateExtension
{
    public static bool IsDiscountActive(this DateTime startDate, DateTime endDate) => DateTime.Now >= startDate && DateTime.Now <= endDate;
}