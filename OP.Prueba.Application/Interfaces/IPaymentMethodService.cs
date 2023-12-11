using OP.Prueba.Application.DTOs.PaymentMethods;
using OP.Prueba.Application.Features.PaymentMethod.Queries.GetAllPaymentMethodsQuery;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<PagedResponse<List<PaymentMethodsDto>>> GetAllPaymentMethods(GetAllPaymentMethodsQuery request, CancellationToken cancellationToken);
    }
}