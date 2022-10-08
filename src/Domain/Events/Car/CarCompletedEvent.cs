using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Domain.Events.Car;
public class CarCompletedEvent:BaseEvent
{
    public CarCompletedEvent(car car)
    {
        Car = car;
    }

    public car Car { get; }
}
