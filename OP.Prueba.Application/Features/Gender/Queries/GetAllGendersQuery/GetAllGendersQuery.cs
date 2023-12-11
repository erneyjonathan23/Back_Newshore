using MediatR;
using OP.Prueba.Application.DTOs.Genders;
using OP.Prueba.Application.DTOs.Roles;
using OP.Prueba.Application.Features.Role.Queries.GetAllRolesQuery;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.Features.Gender.Queries.GetAllGendersQuery
{
    public class GetAllGendersQuery : IRequest<PagedResponse<List<GendersDto>>>
    {
        public int? Id { get; set; } = null;
        public string? Genero { get; set; } = null;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllGendersQuery, PagedResponse<List<GendersDto>>>
    {
        private readonly IGenderService _GenderService;

        public GetAllRolesQueryHandler(IGenderService GenderService)
        {
            this._GenderService = GenderService;
        }

        public async Task<PagedResponse<List<GendersDto>>> Handle(GetAllGendersQuery request, CancellationToken cancellationToken)
        {
            return await _GenderService.GetAllGenders(request, cancellationToken);
        }
    }
}
