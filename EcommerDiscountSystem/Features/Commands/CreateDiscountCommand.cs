using MediatR;

namespace EcommerDiscountSystem.Features.Commands;

public class CreateDiscountCommand : IRequest<bool>
{
    public string CategoryId { get; set; }
    public string DiscountName { get; set; }
    public decimal Rate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, bool>
{
    public Task<bool> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}