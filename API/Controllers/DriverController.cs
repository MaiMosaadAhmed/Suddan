using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SuddanApplication.Application.Common.Models;
using SuddanApplication.Application.Driver.Commands;
using SuddanApplication.Application.Driver.Queries;
using SuddanApplication.Application.CarOwner.Queries;

namespace SuddanApplication.API.Controllers;
[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
public class DriverController : ApiControllerBase
{
   
        [HttpGet]
        public async Task<ActionResult<PaginatedList<DriverBriefDto>>> GetDriverWithPagination([FromQuery] GetDriverWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateDriverCommand command)
        {
        //create application user with driver role and password
        var res = await identity.CreateUserAsync(command.UserName, command.Email, command.Password);
        if (res.Result.Succeeded)
        {
            var res02 = await identity.AddToRoleAsync(res.UserId, "Driver");
            if (res02.Result.Succeeded)
            {
                command.UserId = res02.UserId;
                return await Mediator.Send(command);
            }
        }
        return BadRequest();
    }

    [HttpPost("[action]")]
    //[Route("/Pos")]
    public async Task<ActionResult> AddPos(AddDriverPosCommand command)
    {
        if (uid != "")
        {
            command.UserId = uid;
            return Ok(await Mediator.Send(command));
        }
        return BadRequest();
    }

        [HttpPost("[action]")]
        //[Route("/Pos")]
        public async Task<ActionResult> SOS(SendDriverSOSCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("[action]")]
        //[Route("/Pos")]
        public async Task<ActionResult> Chat(DriverChatCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateDriverCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(int id, UpdateDriverDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteDriverCommand(id));

            return NoContent();
        }
    
}
