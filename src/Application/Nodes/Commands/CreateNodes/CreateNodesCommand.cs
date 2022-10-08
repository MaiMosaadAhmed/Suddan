using MediatR;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Nodes.Commands.CreateNodes;
public record CreateNodesCommand : IRequest<int>
{
     public string Name { get; set; }
    public string GroupId { get; set; }
    public string OrderingGroup { get; set; }
    public string X { get; set; }
    public string Y { get; set; }
}

public class CreateNodesCommandHandler : IRequestHandler<CreateNodesCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateNodesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateNodesCommand request, CancellationToken cancellationToken)
    {
        var entity = new SuddanApplication.Domain.Entities.Nodes
        { 
        
            Name = request.Name,
            GroupId = request.GroupId,
            OrderingGroup = request.OrderingGroup,
            X = request.X,  
            Y = request.Y
        };

        entity.AddDomainEvent(new NodesCreatedEvent(entity));

        _context.Nodes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
