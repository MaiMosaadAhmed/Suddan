using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Nodes.Commands.DeleteNodes;
public record DeleteNodesCommand(int Id) : IRequest;

public class DeleteNodesCommandHandler : IRequestHandler<DeleteNodesCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteNodesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteNodesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Nodes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Nodes), request.Id);
        }

        _context.Nodes.Remove(entity);

        entity.AddDomainEvent(new NodesDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
