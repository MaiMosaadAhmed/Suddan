using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events;

public class DriverCompletedEvent : BaseEvent
{
    public DriverCompletedEvent(Driver driver)
    {
        Driver = driver;
    }

    public Driver Driver { get; }
}
