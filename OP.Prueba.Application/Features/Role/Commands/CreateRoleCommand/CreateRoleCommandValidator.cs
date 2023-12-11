using FluentValidation;

namespace OP.Prueba.Application.Features.CreateRoleCommand.Commands.CreateRoleCommand
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
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