using System.Security.Claims;
using MediatR;

using Microsoft.AspNetCore.Mvc;
using SuddanApplication.Application.Common.Interfaces;

namespace SuddanApplication.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator = null!;
    private ISec _sec = null!;
    private IIdentityService _identity = null!;
    private string? _uid = null;
    private string _uname = null;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    protected ISec sec => _sec ??= HttpContext.RequestServices.GetRequiredService<ISec>();
    protected string uid => _uid == null || _uid == "" ? __uid() : "";
    private string __uid()
    {
        if (User != null
         && User.Identity as ClaimsIdentity != null
         && (User.Identity as ClaimsIdentity).FindFirst(m => m.Type == "uid") != null
         && (User.Identity as ClaimsIdentity).FindFirst(m => m.Type == "uid").Value != null
         && sec.DecryptString((User.Identity as ClaimsIdentity).FindFirst(m => m.Type == "uid").Value) != null)
        {
            return sec.DecryptString((User.Identity as ClaimsIdentity).FindFirst(m => m.Type == "uid").Value);
        }
        return "";
    }
    protected string uname => _uname == null || _uname == "" ? __uname() : "";
    private string __uname()
    {
        if (User != null
         && User.Identity as ClaimsIdentity != null
         && (User.Identity as ClaimsIdentity).FindFirst(m => m.Type == "uid") != null
         && (User.Identity as ClaimsIdentity).FindFirst(m => m.Type == "uid").Value != null
         && sec.DecryptString((User.Identity as ClaimsIdentity).FindFirst(m => m.Type == "uid").Value) != null)
        {
            var user = identity.GetUserNameAsync(sec.DecryptString((User.Identity as ClaimsIdentity).FindFirst(m => m.Type == "uid").Value)).Result;
            return user;
        }
        return "";
    }
    protected IIdentityService identity => _identity ??= HttpContext.RequestServices.GetRequiredService<IIdentityService>();
}
