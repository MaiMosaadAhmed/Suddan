using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Enums;

namespace SuddanApplication.Application.CarOwner.Commands;
public record UpdateCarOwnerDetailCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; set; }
    public string? RecordNo { get; set; }
    public string? passportNo { get; set; }
    public TypeOwner ownerType { get; set; }
    public int PhoneNo { get; set; }
    public int ContactNo { get; set; }
}

public class UpdateCarOwnerDetailCommandHandler : IRequestHandler<UpdateCarOwnerDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCarOwnerDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCarOwnerDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.OwnerCars
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(CarOwner), request.Id);
        }

        entity.Name = request.Name;
        entity.RecordNo = request.RecordNo;
        entity.passportNo = request.passportNo;
        entity.ownerType=request.ownerType;
        entity.PhoneNo = request.PhoneNo;
        entity.ContactNo = request.ContactNo;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
