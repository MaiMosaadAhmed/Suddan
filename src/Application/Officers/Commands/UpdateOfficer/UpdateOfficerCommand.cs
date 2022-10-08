using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Application.Officers.Commands.UpdateOfficer;
public record UpdateOfficerCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; set; }
    public string? Ranks { get; set; }
    public int JobId { get; set; }
    public int OfficerId { get; set; }
    public string? OfficerImg { get; set; }
    public int NodeId { get; set; }
}

public class UpdateOfficerCommandHandler : IRequestHandler<UpdateOfficerCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateOfficerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateOfficerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Officers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(SuddanApplication.Domain.Entities.Officers), request.Id);
        }

        entity.OfficerId = request.Id;
        entity.Name = request.Name;
        entity.Ranks = request.Ranks;
        entity.JobId = request.JobId;
        entity.NodeId=request.NodeId;
        entity.OfficerImg = request.OfficerImg;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
