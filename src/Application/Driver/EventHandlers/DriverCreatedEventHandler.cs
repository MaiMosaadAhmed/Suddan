using MediatR;
using Microsoft.Extensions.Logging;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Driver.EventHandlers;
public class DriverCreatedEventHandler : INotificationHandler<DriverCreatedEvent>
{
    private readonly ILogger<DriverCreatedEventHandler> _logger;

    public DriverCreatedEventHandler(ILogger<DriverCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DriverCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SuddanApplication Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
