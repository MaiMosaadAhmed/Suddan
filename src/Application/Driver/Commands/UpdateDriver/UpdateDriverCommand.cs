using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Application.Driver.Commands;
public record UpdateDriverCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; set; }
    public string? passportId { get; set; }
    public string? LicenseNo { get; set; }
    public string? ProfilerNo { get; set; }
}

public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDriverCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Drivers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Driver), request.Id);
        }

        entity.Name = request.Name;
        entity.passportId = request.passportId;
        entity.LicenseNo= request.LicenseNo;
        entity.ProfilerNo = request.ProfilerNo;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
