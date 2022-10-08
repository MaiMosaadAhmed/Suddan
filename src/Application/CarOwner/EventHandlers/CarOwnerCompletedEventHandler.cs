using MediatR;
using Microsoft.Extensions.Logging;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.CarOwner.EventHandlers;
public class CarOwnerCompletedEventHandler : INotificationHandler<CarOwnerCompletedEvent>
{
    private readonly ILogger<CarOwnerCompletedEventHandler> _logger;

    public CarOwnerCompletedEventHandler(ILogger<CarOwnerCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CarOwnerCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SuddanApplication Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
