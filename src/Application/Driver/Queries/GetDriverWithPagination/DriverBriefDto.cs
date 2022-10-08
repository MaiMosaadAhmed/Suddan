using SuddanApplication.Application.Common.Mappings;
using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Application.Driver.Queries;
public class DriverBriefDto : IMapFrom<SuddanApplication.Domain.Entities.Driver>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? passportId { get; set; }
    public string? LicenseNo { get; set; }
    public string? ProfilerNo { get; set; }
    public int CarId { get; set; }
}