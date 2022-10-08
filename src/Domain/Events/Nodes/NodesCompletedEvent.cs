using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events;

public class NodesCompletedEvent : BaseEvent
{
    public NodesCompletedEvent(Nodes nodes)
    {
        Nodes = nodes;
    }

    public Nodes Nodes { get; }
}
