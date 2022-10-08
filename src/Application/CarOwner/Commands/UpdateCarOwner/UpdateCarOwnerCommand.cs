using MediatR;
using SuddanApplication.Application.Common.Exceptions;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Enums;

namespace SuddanApplication.Application.CarOwner.Commands;
public record UpdateCarOwnerCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; init; }
    public string? RecordNo { get; init; }
    public string? passportNo { get; init; }
    public TypeOwner ownerType { get; init; }
    public int PhoneNo { get; init; }
    public int ContactNo { get; init; }
}

public class UpdateCarOwnerCommandHandler : IRequestHandler<UpdateCarOwnerCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCarOwnerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCarOwnerCommand request, CancellationToken cancellationToken)
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
        entity.ownerType = request.ownerType;       
        entity.PhoneNo=request.PhoneNo;
        entity.ContactNo = request.ContactNo;   

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
