using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.CarOwner.Commands;
public record DeleteCarOwnerCommand(int Id) : IRequest;

public class DeleteCarOwnerCommandHandler : IRequestHandler<DeleteCarOwnerCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCarOwnerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCarOwnerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.OwnerCars
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(CarOwner), request.Id);
        }

        _context.OwnerCars.Remove(entity);

        entity.AddDomainEvent(new CarOwnerDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
