using AutoMapper;
using EcommerDiscountSystem.Dtos;
using EcommerDiscountSystem.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerDiscountSystem.Features.Queries.Product;

public class GetAllProductQuery : IRequest<List<ProductDto>>
{
    
}

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllProductQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.ToListAsync(cancellationToken);
        var productDtos = _mapper.Map<List<ProductDto>>(products);
        for(var i=0;i<products.Count;i++)
            ProductDiscount.CalculateDiscount(products[i], productDtos[i]);
        return productDtos;
    }
}