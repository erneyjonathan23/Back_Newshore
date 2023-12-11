using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.Features.DeleteEmergencyContactCommand.Commands.DeleteEmergencyContactCommand
{
    public class DeleteEmergencyContactCommandValidator : AbstractValidator<DeleteEmergencyContactCommand>
    {
        public DeleteEmergencyContactCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}