using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Officers.Commands.DeleteOfficer;
public record DeleteOfficerCommand(int Id) : IRequest;

public class DeleteOfficerCommandHandler : IRequestHandler<DeleteOfficerCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteOfficerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteOfficerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Officers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(SuddanApplication.Domain.Entities.Officers), request.Id);
        }

        _context.Officers.Remove(entity);

        entity.AddDomainEvent(new OfficersDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
