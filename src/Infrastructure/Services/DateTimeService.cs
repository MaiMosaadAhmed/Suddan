using SuddanApplication.Application.Common.Interfaces;

namespace SuddanApplication.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
