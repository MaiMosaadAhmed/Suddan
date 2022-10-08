using MediatR;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Enums;
using SuddanApplication.Domain.Events;

namespace SuddanApplication.Application.CarOwner.Commands;
public record CreateCarOwnerCommand : IRequest<int>
{
    public string? Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? UserId { get; set; }
    public string? RecordNo { get; set; }
    public string? passportNo { get; set; }
    public TypeOwner ownerType { get; set; }
    public int PhoneNo { get; set; }
    public int ContactNo { get; set; }

}

public class CreateCarOwnerCommandHandler : IRequestHandler<CreateCarOwnerCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCarOwnerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCarOwnerCommand request, CancellationToken cancellationToken)
    {
        var entity = new OwnerCar
        {
            Name = request.Name,
            UserId = request.UserId,
            RecordNo = request.RecordNo,
            passportNo=request.passportNo,
            ownerType = request.ownerType,
            PhoneNo=request.PhoneNo,        
            ContactNo=request.ContactNo,
        };

        entity.AddDomainEvent(new CarOwnerCreatedEvent(entity));

        _context.OwnerCars.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
