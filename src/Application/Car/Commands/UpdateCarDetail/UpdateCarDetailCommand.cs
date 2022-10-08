using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Enums;

namespace SuddanApplication.Application.Car.Commands.UpdateCarDetailCommand;
public record UpdateCarDetailCommand : IRequest
{
    public int Id { get; init; }

    public string? CarPlateNumber { get; init; }
    public string? ImgCarNumber { get; init; }
    public string? LicenceNumber { get; init; }
    public string? ImglicenceNumber { get; init; }
    public string? RFID { get; init; }

}

public class UpdateCarDetailCommandHandler : IRequestHandler<UpdateCarDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCarDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCarDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cars
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TodoItem), request.Id);
        }
entity.CarPlateNumber = request.CarPlateNumber; 
        entity.ImgCarNumber=request.ImgCarNumber;
        entity.ImglicenceNumber=request.ImglicenceNumber;
        entity.CarPlateNumber = request.CarPlateNumber;
        entity.RFID=request.RFID;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
