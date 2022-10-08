using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuddanApplication.Domain.Entities;
public class Nodes:BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? GroupId { get; set; }
    public string? OrderingGroup { get; set; }
    public string? X { get; set; }
    public string? Y { get; set; }
    public IList<Officers> Officers { get; private set; } = new List<Officers>();
    public IList<Driver> Drivers { get; private set; } = new List<Driver>();
    public IList<car> Cars { get; private set; } = new List<car>();

}
