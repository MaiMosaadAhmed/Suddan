using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Application.Car.Commands.UpdateCar;
public record UpdateCarCommand : IRequest
{
    public int Id { get; init; }

    public string? CarPlateNumber { get; init; }
    public string? ImgCarNumber { get; init; }
    public string? LicenceNumber { get; init; }
    public string? ImglicenceNumber { get; init; }
    public string? RFID { get; init; }
    public int DriverId { get; init; }
}

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cars
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TodoItem), request.Id);
        }

       entity.CarPlateNumber=request.CarPlateNumber;
        entity.ImgCarNumber = request.ImgCarNumber;
        entity.ImglicenceNumber = request.ImglicenceNumber;
        entity.RFID = request.RFID;
        entity.DriverId=request.DriverId;
        entity.LicenceNumber = request.LicenceNumber;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
