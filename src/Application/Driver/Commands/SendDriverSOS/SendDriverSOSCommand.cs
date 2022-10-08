using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Driver.Commands;
public record SendDriverSOSCommand : IRequest
{

    public int DriverId { get; init; }
    public string SOS { get; init; }
}

public class SendDriverSOSCommandHandler : IRequestHandler<SendDriverSOSCommand>
{
    //private readonly IApplicationDbContext _context;

    //public SendDriverSOSCommandHandler(IApplicationDbContext context)
    //{
    //    _context = context;
    //}

    public async Task<Unit> Handle(SendDriverSOSCommand request, CancellationToken cancellationToken)
    {
        //var entity = await _context.Drivers
        //    .FindAsync(new object[] { request.DriverId }, cancellationToken);

        //if (entity == null)
        //{
        //    throw new NotFoundException(nameof(Driver), request.DriverId);
        //}

        //for (int i = 0; i < request.Pos.Count; i++)
        //{
        //    var pos = new DriverPos
        //    {
        //        DriverId = request.DriverId,
        //        X = request.Pos[i].X,
        //        Y = request.Pos[i].Y,
        //    };
        //    entity.DriverPos.Add(pos);
        //}
        //_context.Drivers.Update(entity);

        ////entity.AddDomainEvent(new DriverDeletedEvent(entity));

        //await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
