using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OP.Prueba.Application.DTOs.BookingPersons;
using OP.Prueba.Application.Features.BookingPerson.Queries.GetAllBookingPersonsQuery;
using OP.Prueba.Application.Features.CreateBookingPersonCommand.Commands.CreateBookingPersonCommand;
using OP.Prueba.Application.Features.DeleteBookingPersonCommand.Commands.DeleteBookingPersonCommand;
using OP.Prueba.Application.Features.GetBookingPersonByIdQuery.Queries.GetBookingPersonByIdQuery;
using OP.Prueba.Application.Features.UpdateBookingPersonCommand.Commands.UpdateBookingPersonCommand;

namespace OP.Prueba.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BookingPersonsController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BookingPersonsRequest request)
        {
            return Ok(await Mediator.Send(new GetAllBookingPersonsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Id = request.Id,
                Persona = request.Persona,
                Reserva = request.Reserva,
            }));
        }

        //GET api/<controller>/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetBookingPersonByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> Post(CreateBookingPersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/3
        [HttpPut("{id}")]
        [Authorize(Roles = "1,2")]
        public async Task<ActionResult> Put(int id, UpdateBookingPersonCommand command)
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
            return Ok(await Mediator.Send(new DeleteBookingPersonCommand { Id = id }));
        }
    }
}