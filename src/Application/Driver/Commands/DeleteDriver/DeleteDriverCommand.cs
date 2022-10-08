using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Driver.Commands;
public record DeleteDriverCommand(int Id) : IRequest;

public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteDriverCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Drivers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Driver), request.Id);
        }

        _context.Drivers.Remove(entity);

        entity.AddDomainEvent(new DriverDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
