using AutoMapper;
using EcommerDiscountSystem.Dtos;
using EcommerDiscountSystem.Helpers;
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

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken) 
    {
        var category=await _context.Categories.Where(x=>x.Id==request.Id).Include(x=>x.Products).
            FirstOrDefaultAsync(cancellationToken: cancellationToken);
        var catgoryDto = _mapper.Map<CategoryDto>(category);

        for (int i = 0; i < category.Products.Count; i++)
        {
            ProductDiscount.CalculateDiscount(category.Products[i],catgoryDto.Products[i]);
        }
        
        return catgoryDto;
    }
        
}