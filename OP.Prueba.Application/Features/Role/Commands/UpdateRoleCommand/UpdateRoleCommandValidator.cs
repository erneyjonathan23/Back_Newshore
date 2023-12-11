using FluentValidation;

namespace OP.Prueba.Application.Features.UpdateRoleCommand.Commands.UpdateRoleCommand
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Role)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Nivel)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}