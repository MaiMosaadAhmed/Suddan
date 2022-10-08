using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SuddanApplication.Application.Common.Models;
using SuddanApplication.Application.CarOwner.Commands;
using SuddanApplication.Application.CarOwner.Queries;
using MediatR;
using SuddanApplication.Domain.Entities;

namespace SuddanApplication.API.Controllers;
[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
public class CarOwnerController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<CarOwnerBriefDto>>> GetCarOwnerWithPagination([FromQuery] GetCarOwnerWithPaginationQuery query)
    {
        if (uid != "")
        {
            return await Mediator.Send(query);
        }
        return BadRequest();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCarOwnerCommand command)
    {
        //create application user with owner role and password
        var res = await identity.CreateUserAsync(command.UserName, command.Email, command.Password);
        if (res.Result.Succeeded)
        {
            var res02 = await identity.AddToRoleAsync(res.UserId, "Owner");
            if (res02.Result.Succeeded)
            {
                command.UserId = res02.UserId;
                return await Mediator.Send(command);
            }
        }
        return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateCarOwnerCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<PaginatedList<DriverPosResults>>> DriversLocs([FromQuery] GetDriverLocQuery query)
    {
        if (uid != "")
        {
            query.UserId = uid;
            return await Mediator.Send(query);
        }
        return BadRequest();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(int id, UpdateCarOwnerDetailCommand command)
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
        await Mediator.Send(new DeleteCarOwnerCommand(id));

        return NoContent();
    }

}
