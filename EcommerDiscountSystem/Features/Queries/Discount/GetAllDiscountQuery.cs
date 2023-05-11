using AutoMapper;
using EcommerDiscountSystem.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerDiscountSystem.Features.Queries.Discount;

public class GetAllDiscountQuery:IRequest<List<DiscountDto>>
{
    
}

public class GetAllDiscountQueryHandler:IRequestHandler<GetAllDiscountQuery,List<DiscountDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllDiscountQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DiscountDto>> Handle(GetAllDiscountQuery request, CancellationToken cancellationToken) => 
        _mapper.Map<List<DiscountDto>>(await _context.Discounts.ToListAsync(cancellationToken));
}