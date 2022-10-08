using MediatR;
using Microsoft.Extensions.Logging;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Officers.EventHandlers;
public class OfficerCreatedEventHandler : INotificationHandler<OfficerCreatedEvent>
{
    private readonly ILogger<OfficerCreatedEventHandler> _logger;

    public OfficerCreatedEventHandler(ILogger<OfficerCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(OfficerCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SuddanApplication Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
