using AutoMapper;
using OP.Prueba.Application.DTOs.DocumentTypes;
using OP.Prueba.Application.DTOs.PaymentMethods;
using OP.Prueba.Application.DTOs.Roles;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Features.PaymentMethod.Queries.GetAllPaymentMethodsQuery;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Specifications;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IRepositoryAsync<Domain.Entities.MetodosPago> _repositoryAsync;
        private readonly IMapper _mapper;
        public PaymentMethodService(IRepositoryAsync<MetodosPago> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<PagedResponse<List<PaymentMethodsDto>>> GetAllPaymentMethods(GetAllPaymentMethodsQuery request, CancellationToken cancellationToken)
        {
            var paymentMethod = await _repositoryAsync.ListAsync(new PagedPaymentMethodSpecification(request.PageSize, request.PageNumber, request.Id, request.MetodoPago));
            var paymentMethodCount = await _repositoryAsync.CountAsync(new PagedPaymentMethodSpecification(null, null, request.Id, request.MetodoPago));
            var paymentMethodDto = new List<PaymentMethodsDto>();
            if (paymentMethod.Count > 0)
            {
                paymentMethodDto = (from data in paymentMethod
                                    select new PaymentMethodsDto
                                    {
                                        Id = data.Id,
                                        MetodoPago = data.MetodoPago,
                                        FeBaja = data.FeBaja,
                                        FeRegistro = data.FeRegistro
                                    }).ToList();
            }
            return new PagedResponse<List<PaymentMethodsDto>>(paymentMethodDto, request.PageNumber, request.PageSize, paymentMethodCount);
        }
    }
}