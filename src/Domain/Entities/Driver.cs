using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace SuddanApplication.Domain.Entities;
public class Driver: BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? UserId { get; set; }
    public string? passportId { get; set; }
    public string? LicenseNo { get; set; }
    public int DriverNumber { get; init; }
    public string? ProfilerNo { get; set; }
    public int CarId { get; set; }
    public car Car { get; set; } = null!;
    public Collection<DriverPos> DriverPos { get; set; }    


}
