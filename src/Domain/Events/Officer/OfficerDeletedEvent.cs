using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events;

public class OfficersDeletedEvent : BaseEvent
{
    public OfficersDeletedEvent(Officers officers)
    {
        Officers = officers;
    }

    public Officers Officers { get; }
}
