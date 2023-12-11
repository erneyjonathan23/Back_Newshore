using OP.Prueba.Application.Parameters;
using OP.Prueba.Domain.Common;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.DTOs.PaymentMethods
{
    public class PaymentMethodsDto : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string MetodoPago { get; set; }
    }
}