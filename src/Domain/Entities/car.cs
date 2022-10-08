using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuddanApplication.Domain.Entities;
public class car: BaseAuditableEntity
{
    public string? CarPlateNumber { get; set; }
    public string? ImgCarNumber { get; set; }
    public string? LicenceNumber { get; set; }
    public string? ImglicenceNumber { get; set; }
    public string? RFID { get; set; }
    public int DriverId { get; set; }
    public int OwnerId { get; set; }
    public int OwnerCarId { get; set; }
    public OwnerCar OwnerCar { get; set; } = null!;
    public IList<Nodes> Nodes { get; private set; } = new List<Nodes>();
    public IList<Driver> Drivers { get; private set; } = new List<Driver>();



}
