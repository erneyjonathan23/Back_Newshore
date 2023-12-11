using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OP.Prueba.Application.DTOs.Roles;
using OP.Prueba.Application.Features.CreateRoleCommand.Commands.CreateRoleCommand;
using OP.Prueba.Application.Features.DeleteRoleCommand.Commands.DeleteRoleCommand;
using OP.Prueba.Application.Features.GetRoleByIdQuery.Queries.GetRoleByIdQuery;
using OP.Prueba.Application.Features.Role.Queries.GetAllRolesQuery;
using OP.Prueba.Application.Features.UpdateRoleCommand.Commands.UpdateRoleCommand;

namespace OP.Prueba.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RolesController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Get([FromQuery] RolesRequest request)
        {
            return Ok(await Mediator.Send(new GetAllRolesQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Id = request.Id,
                Role = request.Role,
                Nivel = request.Nivel,
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetRoleByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Post(CreateRoleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/3
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> Put(int id, UpdateRoleCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        //DELETE api/<controller>/3
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRoleCommand { Id = id }));
        }
    }
}