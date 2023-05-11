using EcommerDiscountSystem.Models;
using MediatR;

namespace EcommerDiscountSystem.Events;

public class DiscountCreateEvent : INotification
{
    public Discount Discount { get; set; }
}

public class DiscountCreateEventHandler : INotificationHandler<DiscountCreateEvent>
{
    private readonly ILogger<DiscountCreateEventHandler> _logger;

    public DiscountCreateEventHandler(ILogger<DiscountCreateEventHandler> logger)
    {
        _logger = logger;
    }


    public async Task Handle(DiscountCreateEvent notification, CancellationToken cancellationToken)
    {
        // yeni bir indirim oluşturulduğunda kullanıcılara bilgilendirme maili gönderme gibi işlemler yapılabilir.
        _logger.LogInformation($"New Discount Created, discount start date : {notification.Discount.StartDate} - discount end date : {notification.Discount.EndDate}");
    }
}