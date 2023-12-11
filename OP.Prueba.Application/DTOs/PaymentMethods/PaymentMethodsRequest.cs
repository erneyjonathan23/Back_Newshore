using OP.Prueba.Application.Parameters;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.DTOs.PaymentMethods
{
    public class PaymentMethodsRequest : RequestParameter
    {
        public int? Id { get; set; } = null;
        public string? MetodoPago { get; set; } = null;
    }
}
