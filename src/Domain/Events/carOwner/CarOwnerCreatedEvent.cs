using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events;

public class CarOwnerCreatedEvent : BaseEvent
{
    public CarOwnerCreatedEvent(OwnerCar ownerCar)
    {
        OwnerCar = ownerCar;
    }

    public OwnerCar OwnerCar { get; }
}
