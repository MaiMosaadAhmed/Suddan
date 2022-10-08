using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace SuddanApplication.Domain.Entities;
public class DriverPos: BaseAuditableEntity
{
    public int DriverId { get; set; }
    public Driver? Driver { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public DateTime CreatedMob { get; set; }


}
