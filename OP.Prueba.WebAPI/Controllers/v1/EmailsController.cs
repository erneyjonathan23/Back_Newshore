using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OP.Prueba.Application.Features.EmailNotificationCommand.Commands.EmailNotificationCommand;

namespace OP.Prueba.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EmailsController : BaseApiController
    {
        // POST api/<controller>
        [HttpPost("Send")]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> Post(EmailNotificationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}