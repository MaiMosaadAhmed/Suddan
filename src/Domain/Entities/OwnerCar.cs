using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace SuddanApplication.Domain.Entities;
public class OwnerCar:BaseAuditableEntity
{
   public string? Name { get; set; }
    public string? RecordNo { get; set; }
    public string? passportNo { get; set; }
    public string? UserId { get; set; }
    public TypeOwner ownerType { get; set; }
    public int PhoneNo { get; set; }
    public int ContactNo { get; set; }
    public IList<car> Cars { get; private set; } = new List<car>();


}
