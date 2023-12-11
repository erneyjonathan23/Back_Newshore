using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OP.Prueba.Application.DTOs.EmergencyContacts;
using OP.Prueba.Application.Features.EmergencyContact.Queries.GetAllEmergencyContactsQuery;
using OP.Prueba.Application.Features.CreateEmergencyContactCommand.Commands.CreateEmergencyContactCommand;
using OP.Prueba.Application.Features.DeleteEmergencyContactCommand.Commands.DeleteEmergencyContactCommand;
using OP.Prueba.Application.Features.GetEmergencyContactByIdQuery.Queries.GetEmergencyContactByIdQuery;
using OP.Prueba.Application.Features.UpdateEmergencyContactCommand.Commands.UpdateEmergencyContactCommand;

namespace OP.Prueba.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EmergencyContactsController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] EmergencyContactsRequest request)
        {
            return Ok(await Mediator.Send(new GetAllEmergencyContactsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Id = request.Id,
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                NumeroContacto = request.NumeroContacto,
                Email = request.Email,
            }));
        }

        //GET api/<controller>/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetEmergencyContactByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> Post(CreateEmergencyContactCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/3
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> Put(int id, UpdateEmergencyContactCommand command)
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
            return Ok(await Mediator.Send(new DeleteEmergencyContactCommand { Id = id }));
        }
    }
}