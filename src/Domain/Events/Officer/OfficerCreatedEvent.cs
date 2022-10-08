using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events;

public class OfficerCreatedEvent : BaseEvent
{
    public OfficerCreatedEvent(Officers officers)
    {
        Officers = officers;
    }

    public Officers Officers { get; }
}
