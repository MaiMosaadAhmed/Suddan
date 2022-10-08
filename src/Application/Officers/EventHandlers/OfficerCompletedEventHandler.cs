using MediatR;
using Microsoft.Extensions.Logging;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Officers.EventHandlers;
public class OfficerCompletedEventHandler : INotificationHandler<OfficerCompletedEvent>
{
    private readonly ILogger<OfficerCompletedEventHandler> _logger;

    public OfficerCompletedEventHandler(ILogger<OfficerCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(OfficerCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SuddanApplication Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
