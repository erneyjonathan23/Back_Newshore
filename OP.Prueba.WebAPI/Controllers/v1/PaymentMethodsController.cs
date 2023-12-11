using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OP.Prueba.Application.DTOs.PaymentMethods;
using OP.Prueba.Application.Features.PaymentMethod.Queries.GetAllPaymentMethodsQuery;

namespace OP.Prueba.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PaymentMethodsController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        //[Authorize(Roles = "1")]
        public async Task<IActionResult> Get([FromQuery] PaymentMethodsRequest request)
        {
            return Ok(await Mediator.Send(new GetAllPaymentMethodsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Id = request.Id,
                MetodoPago = request.MetodoPago,
            }));
        }
    }
}