using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SuddanApplication.Application.Common.Models;
using SuddanApplication.Application.Car.Commands.CreateCar;
using SuddanApplication.Application.Car.Commands.DeleteCar;
using SuddanApplication.Application.Car.Commands.UpdateCar;
using SuddanApplication.Application.Car.Commands.UpdateCarDetailCommand;
using SuddanApplication.Application.Car.Queries.GetCarWithPagination;
using MediatR;

namespace SuddanApplication.API.Controllers;
[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
public class CarController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<CarBriefDto>>> GetCarWithPagination([FromQuery] GetCarsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCarCommand command)
    {
        if (uid!="")
        {
            command.UserId = uid;
            return await Mediator.Send(command);
        }
        return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateCarCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(int id, UpdateCarDetailCommand command)
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
        await Mediator.Send(new DeleteCarCommand(id));

        return NoContent();
    }


}
