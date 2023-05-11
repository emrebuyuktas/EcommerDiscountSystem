using EcommerDiscountSystem.Dtos;
using EcommerDiscountSystem.Models;

namespace EcommerDiscountSystem.Helpers;

public static class ProductDiscount
{
    public static void CalculateDiscount(Product product, ProductDto productDto)
    {
        if (product.Category.Discount == null ||
            !product.Category.Discount.StartDate.IsDiscountActive(product.Category.Discount.EndDate)) return;
        productDto.DiscountedPrice = product.Price - (product.Price * product.Category.Discount.Rate / 100);
        productDto.DiscountRate = product.Category.Discount.Rate;

    }
}