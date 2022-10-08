using MediatR;
using Microsoft.Extensions.Logging;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Driver.EventHandlers;
public class DriverCompletedEventHandler : INotificationHandler<DriverCompletedEvent>
{
    private readonly ILogger<DriverCompletedEventHandler> _logger;

    public DriverCompletedEventHandler(ILogger<DriverCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DriverCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SuddanApplication Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
