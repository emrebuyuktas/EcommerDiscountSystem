using AutoMapper;
using EcommerDiscountSystem.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerDiscountSystem.Features.Queries.Category;

public class GetAllCategoriesQuery:IRequest<List<CategoryDto>>
{
    
}

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)=>
        _mapper.Map<List<CategoryDto>>(await _context.Categories.ToListAsync(cancellationToken));
}
