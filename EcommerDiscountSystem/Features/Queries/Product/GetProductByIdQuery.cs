using AutoMapper;
using EcommerDiscountSystem.Dtos;
using EcommerDiscountSystem.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerDiscountSystem.Features.Queries.Product;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public GetProductByIdQuery(string ıd)
    {
        Id = ıd;
    }

    public string Id { get; set; }
}

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.Where(x=>x.Id==request.Id).Include(x=>x.Category).
            ThenInclude(x=>x.Discount).FirstOrDefaultAsync(cancellationToken);
        var productDto= _mapper.Map<ProductDto>(product);
        ProductDiscount.CalculateDiscount(product, productDto);
        return productDto;
    }
}