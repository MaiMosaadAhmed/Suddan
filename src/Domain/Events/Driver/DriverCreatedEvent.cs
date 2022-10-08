using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events;

public class DriverCreatedEvent : BaseEvent
{
    public DriverCreatedEvent(Driver driver)
    {
        Driver = driver;
    }

    public Driver Driver { get; }
}
