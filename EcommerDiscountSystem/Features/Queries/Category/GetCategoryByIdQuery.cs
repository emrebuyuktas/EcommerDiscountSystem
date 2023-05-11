using AutoMapper;
using EcommerDiscountSystem.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerDiscountSystem.Features.Queries.Category;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public GetCategoryByIdQuery(string ıd)
    {
        Id = ıd;
    }

    public string Id { get; set; }
}

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken) =>
        _mapper.Map<CategoryDto>(await _context.Categories.Where(x=>x.Id==request.Id).Include(x=>x.Products).ToListAsync(cancellationToken: cancellationToken));
}