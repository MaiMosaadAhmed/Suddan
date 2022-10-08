using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events;

public class CarOwnerCompletedEvent : BaseEvent
{
    public CarOwnerCompletedEvent(OwnerCar ownerCar)
    {
        OwnerCar = ownerCar;
    }

    public OwnerCar OwnerCar { get; }
}
