using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events;

public class NodesDeletedEvent : BaseEvent
{
    public NodesDeletedEvent(Nodes node)
    {
        Node = node;
    }

    public Nodes Node { get; }
}
