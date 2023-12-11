using FluentValidation;

namespace OP.Prueba.Application.Features.CreateBookingCommand.Commands.CreateBookingCommand
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Usuario)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Estado)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.FechaInicio)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}