using System.Security.Claims;

using SuddanApplication.Application.Common.Interfaces;

namespace SuddanApplication.API.Services;
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private ISec _sec = null!;
    //protected ISec sec => _sec ??= HttpContext.RequestServices.GetRequiredService<ISec>();

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, ISec sec)
    {
        _httpContextAccessor = httpContextAccessor;
        _sec = sec;
    }

    public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue("uid")!=null?_sec.DecryptString(_httpContextAccessor.HttpContext?.User?.FindFirstValue("uid")):null;
}
