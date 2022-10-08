using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Enums;

namespace SuddanApplication.Application.Driver.Commands;
public record UpdateDriverDetailCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? passportId { get; init; }
    public string? LicenseNo { get; init; }
    public string? ProfilerNo { get; init; }
}
    public class UpdateDriverDetailCommandHandler : IRequestHandler<UpdateDriverDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDriverDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateDriverDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Drivers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Driver), request.Id);
        }

        entity.Name = request.Name;
        entity.passportId = request.passportId;
        entity.LicenseNo = request.LicenseNo;
            entity.ProfilerNo = request.ProfilerNo;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
