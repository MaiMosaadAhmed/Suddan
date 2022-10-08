using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuddanApplication.Domain.Entities;
public class Officers: BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? Ranks { get; set; }
    public string? UserId { get; set; }
    public int JobId { get; set; }
    public int OfficerId { get; set; }
    public string? OfficerImg { get; set; }
    public int NodeId { get; set; }
    public IList<Driver> Drivers { get; private set; } = new List<Driver>();
    public Nodes nodes { get; set; } = null!;


}
