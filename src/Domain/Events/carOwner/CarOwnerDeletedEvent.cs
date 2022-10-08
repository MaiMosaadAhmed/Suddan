using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events;

public class CarOwnerDeletedEvent : BaseEvent
{
    public CarOwnerDeletedEvent(OwnerCar ownerCar)
    {
        OwnerCar = ownerCar;
    }

    public OwnerCar OwnerCar { get; }
}
