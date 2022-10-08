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
public class CarCompletedEventHandler: INotificationHandler<CarCompletedEvent>
{

    private readonly ILogger<CarCompletedEventHandler> _logger;

    public CarCompletedEventHandler(ILogger<CarCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CarCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SuddanApplication Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}