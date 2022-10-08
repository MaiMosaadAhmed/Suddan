using SuddanApplication.Application.Common.Mappings;
using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Application.Officers.Queries.GetOfficerWithPagination;
public class OfficerBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Ranks { get; set; }
    public int JobId { get; set; }
    public int OfficerId { get; set; }
    public string? OfficerImg { get; set; }
    public int NodeId { get; set; }
}
