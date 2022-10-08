using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using SuddanApplication.Domain.Events;
using SuddanApplication.Domain.Events.Car;

namespace SuddanApplication.Application.Car.EventHandlers;
public class CarCreatedEventHandler: INotificationHandler<CarCreatedEvent>
{

    private readonly ILogger<CarCreatedEventHandler> _logger;

    public CarCreatedEventHandler(ILogger<CarCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CarCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SuddanApplication Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
