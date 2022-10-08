using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuddanApplication.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok();
    }
}
