using FluentValidation;

namespace OP.Prueba.Application.Features.CreateEmergencyContactCommand.Commands.CreateEmergencyContactCommand
{
    public class CreateEmergencyContactCommandValidator : AbstractValidator<CreateEmergencyContactCommand>
    {
        public CreateEmergencyContactCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Nombres)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Apellidos)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.NumeroContacto)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}