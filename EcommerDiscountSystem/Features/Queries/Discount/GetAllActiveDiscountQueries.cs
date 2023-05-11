using AutoMapper;
using EcommerDiscountSystem.Dtos;
using EcommerDiscountSystem.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerDiscountSystem.Features.Queries.Discount;

public class GetAllActiveDiscountQueries:IRequest<List<DiscountDto>>
{
    
}

public class GetAllActiveDiscountQueriesHandler : IRequestHandler<GetAllActiveDiscountQueries, List<DiscountDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllActiveDiscountQueriesHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DiscountDto>> Handle(GetAllActiveDiscountQueries request, CancellationToken cancellationToken)=> 
         _mapper.Map<List<DiscountDto>>(await _context.Discounts.Where(x => x.StartDate.IsDiscountActive(x.EndDate)).ToListAsync(cancellationToken));
}