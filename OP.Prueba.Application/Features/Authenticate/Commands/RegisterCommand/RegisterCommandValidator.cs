using FluentValidation;

namespace OP.Prueba.Application.Features.Authenticate.Commands.RegisterCommand
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.Usuario)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.Contrasena)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(500).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.ConfirmarContrasena)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(500).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.Role)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

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

            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.TelefonoContacto)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}
