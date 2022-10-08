using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SuddanApplication.Application.Common.Models;
using SuddanApplication.Application.Officers.Commands.CreateOfficer;
using SuddanApplication.Application.Officers.Commands.DeleteOfficer;
using SuddanApplication.Application.Officers.Commands.UpdateOfficer;
using SuddanApplication.Application.Officers.Commands.UpdateOfficerDetail;
using SuddanApplication.Application.Officers.Queries.GetOfficerWithPagination;

namespace SuddanApplication.API.Controllers;
//[Authorize]

public class OfficersController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<OfficerBriefDto>>> GetOfficerWithPagination([FromQuery] GetOfficerWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateOfficerCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateOfficerCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(int id, UpdateOfficerDetailCommand command)
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
        await Mediator.Send(new DeleteOfficerCommand(id));

        return NoContent();
    }

}
