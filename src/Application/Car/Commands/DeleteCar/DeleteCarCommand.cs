using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Events;
using SuddanApplication.Domain.Events.Car;

namespace SuddanApplication.Application.Car.Commands.DeleteCar;
public record DeleteCarCommand(int Id) : IRequest;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cars
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(car), request.Id);
        }

        _context.Cars.Remove(entity);

        entity.AddDomainEvent(new CarDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
