using FluentValidation;

namespace OP.Prueba.Application.Features.CreateBookingPersonCommand.Commands.CreateBookingPersonCommand
{
    public class CreateBookingPersonCommandValidator : AbstractValidator<CreateBookingPersonCommand>
    {
        public CreateBookingPersonCommandValidator()
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