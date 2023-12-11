using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.Features.DeleteBookingPersonCommand.Commands.DeleteBookingPersonCommand
{
    public class DeleteBookingPersonCommandValidator : AbstractValidator<DeleteBookingPersonCommand>
    {
        public DeleteBookingPersonCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}