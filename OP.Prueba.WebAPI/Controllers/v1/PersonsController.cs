using Microsoft.AspNetCore.Mvc;
using OP.Prueba.Application.DTOs.Persons;
using OP.Prueba.Application.Features.Person.Queries.GetAllPersonsQuery;
using OP.Prueba.Application.Features.CreatePersonCommand.Commands.CreatePersonCommand;
using OP.Prueba.Application.Features.DeletePersonCommand.Commands.DeletePersonCommand;
using OP.Prueba.Application.Features.GetPersonByIdQuery.Queries.GetPersonByIdQuery;
using OP.Prueba.Application.Features.UpdatePersonCommand.Commands.UpdatePersonCommand;
using Microsoft.AspNetCore.Authorization;

namespace OP.Prueba.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PersonsController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PersonsRequest request)
        {
            return Ok(await Mediator.Send(new GetAllPersonsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Id = (int)request.Id,
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                FechaNacimiento = (DateTime)request.FechaNacimiento,
                Genero = (int)request.Genero,
                TipoDocumento = (int)request.TipoDocumento,
                NumeroDocumento = request.NumeroDocumento,
                Email = request.Email,
                TelefonoContacto = (long)request.TelefonoContacto,
                Usuario = request.Usuario,
            }));
        }

        //GET api/<controller>/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPersonByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> Post(CreatePersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/3
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> Put(int id, UpdatePersonCommand command)
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
            return Ok(await Mediator.Send(new DeletePersonCommand { Id = id }));
        }
    }
}