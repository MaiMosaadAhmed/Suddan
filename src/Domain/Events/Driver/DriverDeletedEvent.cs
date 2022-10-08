using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events;

public class DriverDeletedEvent : BaseEvent
{
    public DriverDeletedEvent(Driver driver)
    {
        Driver = driver;
    }

    public Driver Driver { get; }
}
