using MediatR;

namespace EcommerDiscountSystem.Features.Commands.Discount;

public class DeleteDiscountCommand : IRequest<bool>
{
    public DeleteDiscountCommand(string ıd)
    {
        Id = ıd;
    }

    public string Id { get; set; }
}

public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, bool>
{
    private readonly IAppDbContext _context;

    public DeleteDiscountCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
    {
        _context.Discounts.Remove(await _context.Discounts.FindAsync(request.Id, cancellationToken));
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}