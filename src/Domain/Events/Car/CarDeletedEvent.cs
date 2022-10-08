using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuddanApplication.Domain.Events.Car;
public class CarDeletedEvent: BaseEvent
{
    public CarDeletedEvent(car car)
    {
        Car = car;
    }

    public car Car { get; }
}
