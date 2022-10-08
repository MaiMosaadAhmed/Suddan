using SuddanApplication.Application.Common.Mappings;
using SuddanApplication.Domain.Entities;
using SuddanApplication.Domain.Enums;

namespace SuddanApplication.Application.CarOwner.Queries;
public class CarOwnerBriefDto : IMapFrom<OwnerCar>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? RecordNo { get; set; }
    public string? passportNo { get; set; }
    public TypeOwner ownerType { get; set; }
    public int PhoneNo { get; set; }
    public int ContactNo { get; set; }

}
