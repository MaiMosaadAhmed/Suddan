using MediatR;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Events;
using SuddanApplication.Domain.Events.Car;

namespace SuddanApplication.Application.Car.Commands.CreateCar;
public record CreateCarCommand : IRequest<int>
{

    public string? CarPlateNumber { get; set; }
    public string? ImgCarNumber { get; set; }
    public string? LicenceNumber { get; set; }
    public string? ImglicenceNumber { get; set; }
    public string? RFID { get; set; }
    public string? UserId { get; set; }
    //public int? DriverId { get; set; }
}

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        car entity = null;
        if (request.UserId!=null && request.UserId!="")
        {
            var owner = _context.OwnerCars.FirstOrDefault(f => f.UserId == request.UserId);
            if (owner != null)
            {
                entity = new car
                {
                    CarPlateNumber = request.CarPlateNumber,
                    ImgCarNumber = request.ImgCarNumber,
                    LicenceNumber = request.LicenceNumber,
                    RFID = request.RFID,
                    OwnerId = owner.Id,
                    OwnerCarId = owner.Id
                };

                entity.AddDomainEvent(new CarCreatedEvent(entity));

                _context.Cars.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        return entity != null ? entity.Id : 0;
    }
}
