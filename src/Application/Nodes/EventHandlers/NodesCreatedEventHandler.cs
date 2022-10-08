using MediatR;
using Microsoft.Extensions.Logging;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Nodes.EventHandlers;
public class NodesCreatedEventHandler : INotificationHandler<NodesCreatedEvent>
{
    private readonly ILogger<NodesCreatedEventHandler> _logger;

    public NodesCreatedEventHandler(ILogger<NodesCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(NodesCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SuddanApplication Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
