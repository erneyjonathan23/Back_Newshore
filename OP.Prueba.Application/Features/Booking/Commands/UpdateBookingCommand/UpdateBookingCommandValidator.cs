using FluentValidation;

namespace OP.Prueba.Application.Features.UpdateBookingCommand.Commands.UpdateBookingCommand
{
    public class UpdateBookingCommandValidator : AbstractValidator<UpdateBookingCommand>
    {
        public UpdateBookingCommandValidator()
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