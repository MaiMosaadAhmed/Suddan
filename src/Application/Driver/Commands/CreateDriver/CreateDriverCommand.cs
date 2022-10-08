using MediatR;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.Driver.Commands;
public record CreateDriverCommand : IRequest<int>
{

    public string? Name { get; init; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? UserId { get; set; }
    public string? passportId { get; init; }
    public string? LicenseNo { get; init; }
    public string? ProfilerNo { get; init; }
    public int DriverNumber { get; init; }
    public int CarId { get; init; }
}

public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateDriverCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
    {
        var entity = new SuddanApplication.Domain.Entities.Driver
        {
            Name = request.Name,
            UserId = request.UserId,
            passportId = request.passportId,
            LicenseNo = request.LicenseNo,
            ProfilerNo = request.ProfilerNo,
            DriverNumber = request.DriverNumber,
            CarId = request.CarId,

        };

        entity.AddDomainEvent(new DriverCreatedEvent(entity));

        _context.Drivers.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
