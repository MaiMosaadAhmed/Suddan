using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events;

public class OfficerCompletedEvent : BaseEvent
{
    public OfficerCompletedEvent(Officers officers)
    {
        Officers = officers;
    }

    public Officers Officers { get; }
}
