using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Enums;

namespace SuddanApplication.Application.Nodes.Commands.UpdateNodesDetail;
public record UpdateNodesDetailCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; set; }
    public string? GroupId { get; set; }
    public string? OrderingGroup { get; set; }
    public string? X { get; set; }
    public string? Y { get; set; }
}

public class UpdateNodesDetailCommandHandler : IRequestHandler<UpdateNodesDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateNodesDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateNodesDetailCommand request, CancellationToken cancellationToken)
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
