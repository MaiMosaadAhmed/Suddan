using MediatR;
using Microsoft.EntityFrameworkCore;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Driver.Commands;
public record AddDriverPosCommand : IRequest
{
    public string? UserId { get; set; }
    //public int DriverId { get; init; }
    public List<Pos> Pos { get; init; }
}
public record Pos
{
    public float X { get; init; }
    public float Y { get; init; }
    //[System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
    public string Created { get; init; }
}

public class AddDriverPosCommandHandler : IRequestHandler<AddDriverPosCommand>
{
    private readonly IApplicationDbContext _context;

    public AddDriverPosCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AddDriverPosCommand request, CancellationToken cancellationToken)
    {
        //var entity = await _context.Drivers
        //    .FindAsync(new object[] { request.DriverId }, cancellationToken);
        var entity = await _context.Drivers.FirstOrDefaultAsync(f => f.UserId == request.UserId);
            //.FindAsync(new object[] { request.DriverId }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Driver), request.UserId);
        }

        for (int i = 0; i < request.Pos.Count; i++)
        {
            if (DateTime.TryParseExact(request.Pos[i].Created, "dd-MM-yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime dd))
            {
                var pos = new DriverPos
                {
                    DriverId = entity.Id,
                    X = request.Pos[i].X,
                    Y = request.Pos[i].Y,
                    CreatedMob = dd,
                };
                if (entity.DriverPos == null)
                    entity.DriverPos = new System.Collections.ObjectModel.Collection<DriverPos>();
                entity.DriverPos.Add(pos);
            }
        }
        _context.Drivers.Update(entity);

        //entity.AddDomainEvent(new DriverDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
