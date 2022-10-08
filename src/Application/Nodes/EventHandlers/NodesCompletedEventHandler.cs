using MediatR;
using Microsoft.Extensions.Logging;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Nodes.EventHandlers;
public class NodesCompletedEventHandler : INotificationHandler<NodesCompletedEvent>
{
    private readonly ILogger<NodesCompletedEventHandler> _logger;

    public NodesCompletedEventHandler(ILogger<NodesCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(NodesCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SuddanApplication Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
