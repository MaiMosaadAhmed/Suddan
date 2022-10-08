using MediatR;
using Microsoft.Extensions.Logging;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.CarOwner.EventHandlers;
public class CarOwnerCreatedEventHandler : INotificationHandler<CarOwnerCreatedEvent>
{
    private readonly ILogger<CarOwnerCreatedEventHandler> _logger;

    public CarOwnerCreatedEventHandler(ILogger<CarOwnerCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CarOwnerCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SuddanApplication Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
