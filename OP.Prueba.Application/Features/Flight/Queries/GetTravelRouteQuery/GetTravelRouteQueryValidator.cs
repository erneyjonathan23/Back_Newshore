using FluentValidation;

namespace OP.Prueba.Application.Features.Flight.Queries.GetTravelRouteQuery
{
    public class GetTravelRouteQueryValidator : AbstractValidator<GetTravelRouteQuery>
    {
        public GetTravelRouteQueryValidator()
        {
            RuleFor(p => p.Origin)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(3).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.Destination)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(3).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.Origin)
                .NotEqual(p => p.Destination).WithMessage("El origen y el destino deben ser diferentes.");
        }
    }
}