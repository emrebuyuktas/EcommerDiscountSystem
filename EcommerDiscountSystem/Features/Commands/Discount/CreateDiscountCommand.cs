using AutoMapper;
using EcommerDiscountSystem.Dtos;
using EcommerDiscountSystem.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerDiscountSystem.Features.Commands.Discount;

public class CreateDiscountCommand : IRequest<DiscountDto>
{
    public CreateDiscountCommand(CreateDiscountDto discountDto)
    {
        DiscountDto = discountDto;
    }

    public CreateDiscountDto DiscountDto { get; set; }
}

public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, DiscountDto>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public CreateDiscountCommandHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<DiscountDto> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var discount=_mapper.Map<Models.Discount>(request.DiscountDto);
        var categories = await _context.Categories.Where(x => request.DiscountDto.CategoryId.Contains(x.Id)).ToListAsync(cancellationToken);
        discount.Categories = categories;
        await _context.Discounts.AddAsync(discount, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        await _mediator.Publish(new DiscountCreateEvent { Discount = discount }, cancellationToken);
        return _mapper.Map<DiscountDto>(discount);
    }
}