using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SuddanApplication.Application.Common.Models;
using SuddanApplication.Application.Nodes.Commands.CreateNodes;
using SuddanApplication.Application.Nodes.Commands.DeleteNodes;
using SuddanApplication.Application.Nodes.Commands.UpdateNodes;
using SuddanApplication.Application.Nodes.Commands.UpdateNodesDetail;
using SuddanApplication.Application.Nodes.Queries.GetNodesWithPagination;
using MediatR;

namespace SuddanApplication.API.Controllers;
//[Authorize]
public class NodesController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<NodesBriefDto>>> GetNodesWithPagination([FromQuery] GetNodesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateNodesCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateNodesCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(int id, UpdateNodesDetailCommand command)
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
        await Mediator.Send(new DeleteNodesCommand(id));

        return NoContent();
    }

}
