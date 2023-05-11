using AutoMapper;
using EcommerDiscountSystem.Models;

namespace EcommerDiscountSystem.Dtos.Mapping;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<CreateDiscountDto, Discount>().ReverseMap();
        CreateMap<DiscountDto, Discount>().ReverseMap();
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<ProductDto, Product>().ReverseMap();
    }
}