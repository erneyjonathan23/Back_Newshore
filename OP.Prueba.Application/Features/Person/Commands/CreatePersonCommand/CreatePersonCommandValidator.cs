using FluentValidation;

namespace OP.Prueba.Application.Features.CreatePersonCommand.Commands.CreatePersonCommand
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(p => p.Nombres)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.Apellidos)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.FechaNacimiento)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Genero)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.TipoDocumento)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.NumeroDocumento)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");
        }
    }
}