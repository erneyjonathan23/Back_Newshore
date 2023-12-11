using MediatR;
using OP.Prueba.Application.DTOs.DocumentTypes;
using OP.Prueba.Application.DTOs.PaymentMethods;
using OP.Prueba.Application.Features.DocumentType.Queries.GetAllDocumentTypesQuery;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.Features.PaymentMethod.Queries.GetAllPaymentMethodsQuery
{
    public class GetAllPaymentMethodsQuery : IRequest<PagedResponse<List<PaymentMethodsDto>>>
    {
        public int? Id { get; set; } = null;
        public string? MetodoPago { get; set; } = null;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllPaymentMethodsQueryHandler : IRequestHandler<GetAllPaymentMethodsQuery, PagedResponse<List<PaymentMethodsDto>>>
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public GetAllPaymentMethodsQueryHandler(IPaymentMethodService paymentMethodService)
        {
            this._paymentMethodService = paymentMethodService;
        }

        public async Task<PagedResponse<List<PaymentMethodsDto>>> Handle(GetAllPaymentMethodsQuery request, CancellationToken cancellationToken)
        {
            return await _paymentMethodService.GetAllPaymentMethods(request, cancellationToken);
        }
    }
}
