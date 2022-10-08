using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events;

public class NodesCreatedEvent : BaseEvent
{
    public NodesCreatedEvent(Nodes node)
    {
        Node = node;
    }

    public Nodes Node { get; }
}
