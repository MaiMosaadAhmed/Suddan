using MediatR;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Officers.Commands.CreateOfficer;
public record CreateOfficerCommand : IRequest<int>
{
    public string? Name { get; set; }
    public string? Ranks { get; set; }
    public int JobId { get; set; }
    public int OfficerId { get; set; }
    public string? OfficerImg { get; set; }
    public int NodeId { get; set; }
}

public class CreateOfficerCommandHandler : IRequestHandler<CreateOfficerCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateOfficerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateOfficerCommand request, CancellationToken cancellationToken)
    {
        var entity = new SuddanApplication.Domain.Entities.Officers
        {
            Name = request.Name,
            Ranks = request.Ranks,
            JobId = request.JobId,
            OfficerId = request.OfficerId,
            OfficerImg = request.OfficerImg,
            NodeId = request.NodeId
        };

        entity.AddDomainEvent(new OfficerCreatedEvent(entity));

        _context.Officers.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
