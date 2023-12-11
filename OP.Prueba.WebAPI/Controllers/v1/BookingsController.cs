using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OP.Prueba.Application.DTOs.Bookings;
using OP.Prueba.Application.Features.Booking.Queries.GetAllBookingsQuery;
using OP.Prueba.Application.Features.ChangeStatusBookingCommand.Commands.ChangeStatusBookingCommand;
using OP.Prueba.Application.Features.CreateBookingCommand.Commands.CreateBookingCommand;
using OP.Prueba.Application.Features.DeleteBookingCommand.Commands.DeleteBookingCommand;
using OP.Prueba.Application.Features.GetBookingByIdQuery.Queries.GetBookingByIdQuery;
using OP.Prueba.Application.Features.UpdateBookingCommand.Commands.UpdateBookingCommand;

namespace OP.Prueba.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BookingsController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BookingsRequest request)
        {
            return Ok(await Mediator.Send(new GetAllBookingsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Id = request.Id,
                Usuario = request.Usuario,
                Estado = request.Estado,
                TipoViaje = request.TipoViaje,
                Origen = request.Origen,
                Destino = request.Destino,
                Precio = request.Precio,
                NumeroPersonas = request.NumeroPersonas,
            }));
        }

        //GET api/<controller>/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetBookingByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> Post(CreateBookingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/3
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> Put(int id, UpdateBookingCommand command)
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
            return Ok(await Mediator.Send(new DeleteBookingCommand { Id = id }));
        }

        //PUT api/<controller>/3
        [HttpPut("Status/{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> Status(int id)
        {
            if (id == 0)
                return BadRequest();
            return Ok(await Mediator.Send(new ChangeStatusBookingCommand { Id = id }));
        }
    }
}