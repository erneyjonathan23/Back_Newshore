using FluentValidation;

namespace OP.Prueba.Application.Features.UpdateEmergencyContactCommand.Commands.UpdateEmergencyContactCommand
{
    public class UpdateEmergencyContactCommandValidator : AbstractValidator<UpdateEmergencyContactCommand>
    {
        public UpdateEmergencyContactCommandValidator()
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