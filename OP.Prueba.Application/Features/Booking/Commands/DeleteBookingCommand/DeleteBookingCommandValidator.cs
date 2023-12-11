using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.Features.DeleteBookingCommand.Commands.DeleteBookingCommand
{
    public class DeleteBookingCommandValidator : AbstractValidator<DeleteBookingCommand>
    {
        public DeleteBookingCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}