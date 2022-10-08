using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuddanApplication.Domain.Events.Car;
public class CarCreatedEvent: BaseEvent
{
    public CarCreatedEvent(car car)
    {
        Car = car;
    }

    public car Car { get; }
}
