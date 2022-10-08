using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuddanApplication.Application.Common.Mappings;
using SuddanApplication.Domain.Entities;

namespace SuddanApplication.Application.Car.Queries.GetCarWithPagination;
public class CarBriefDto: IMapFrom<car>
{
    public int Id { get; set; }
    public string? CarPlateNumber { get; set; }
    public string? ImgCarNumber { get; set; }
    public string? LicenceNumber { get; set; }
    public string? ImglicenceNumber { get; set; }
    public string? RFID { get; set; }
    public int DriverId { get; set; }
    public int OwnerId { get; set; }
}
