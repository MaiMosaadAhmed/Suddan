using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Application.Nodes.Commands.UpdateNodes;
public record UpdateNodesCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; init; }
    public string? GroupId { get; init; }
    public string? OrderingGroup { get; init; }
    public string? X { get; set; }
    public string? Y { get; set; }
}

public class UpdateNodesCommandHandler : IRequestHandler<UpdateNodesCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateNodesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateNodesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Nodes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Nodes), request.Id);
        }

        entity.Name = request.Name;
        entity.GroupId = request.GroupId;   
        entity.OrderingGroup = request.OrderingGroup;
        entity.X = request.X;
        entity.Y = request.Y;   


        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
