using FluentValidation;

namespace OP.Prueba.Application.Features.UpdateBookingPersonCommand.Commands.UpdateBookingPersonCommand
{
    public class UpdateBookingPersonCommandValidator : AbstractValidator<UpdateBookingPersonCommand>
    {
        public UpdateBookingPersonCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Persona)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Reserva)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}