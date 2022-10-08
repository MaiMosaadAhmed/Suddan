using SuddanApplication.Application.Common.Mappings;
using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Application.Nodes.Queries.GetNodesWithPagination;
public class NodesBriefDto : IMapFrom<SuddanApplication.Domain.Entities.Nodes>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? GroupId { get; set; }
    public string? OrderingGroup { get; set; }
    public string? X { get; set; }
    public string? Y { get; set; }
}
