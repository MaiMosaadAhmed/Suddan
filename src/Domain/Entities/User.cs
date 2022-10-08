using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuddanApplication.Domain.Entities;
public class User: BaseAuditableEntity
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
