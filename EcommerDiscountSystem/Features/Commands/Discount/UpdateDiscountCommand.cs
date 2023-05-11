using AutoMapper;
using EcommerDiscountSystem.Dtos;
using EcommerDiscountSystem.Events;
using EcommerDiscountSystem.Helpers;
using MediatR;

namespace EcommerDiscountSystem.Features.Commands.Discount;

public class UpdateDiscountCommand:IRequest<DiscountDto>
{
    public UpdateDiscountCommand(DiscountDto discountDto)
    {
        DiscountDto = discountDto;
    }

    public DiscountDto DiscountDto { get; set; }
}

public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, DiscountDto>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public UpdateDiscountCommandHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<DiscountDto> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
    {
        var discount = _mapper.Map<Models.Discount>(request.DiscountDto);
        _context.Discounts.Update(discount);
        if(discount.StartDate.IsDiscountActive(discount.EndDate)) await _mediator.Publish(new DiscountCreateEvent { Discount = discount }, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return request.DiscountDto;
    }
}