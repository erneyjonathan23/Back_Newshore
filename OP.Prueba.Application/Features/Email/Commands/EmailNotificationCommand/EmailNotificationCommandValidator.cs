using FluentValidation;

namespace OP.Prueba.Application.Features.EmailNotificationCommand.Commands.EmailNotificationCommand
{
    public class EmailNotificationCommandValidator : AbstractValidator<EmailNotificationCommand>
    {
        public EmailNotificationCommandValidator()
        {
            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Tipo)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Origen)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.IdReserva)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.NombreCompleto)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}