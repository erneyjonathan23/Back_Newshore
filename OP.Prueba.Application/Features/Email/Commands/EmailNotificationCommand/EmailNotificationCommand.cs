using AutoMapper;
using MediatR;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Services;
using OP.Prueba.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Prueba.Application.Features.EmailNotificationCommand.Commands.EmailNotificationCommand
{
    public class EmailNotificationCommand : IRequest<Response<bool>>
    {
        public string? Email { get; set; }
        public string? Tipo { get; set; }
        public string? Origen { get; set; }
        public int? IdReserva { get; set; }
        public string? NombreCompleto { get; set; }
    }
    public class EmailNotificationCommandHandler : IRequestHandler<EmailNotificationCommand, Response<bool>>
    {
        private readonly IEmailService _emailService;

        public EmailNotificationCommandHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<Response<bool>> Handle(EmailNotificationCommand request, CancellationToken cancellationToken)
        {
            return await _emailService.NotifyCreationReservation(request, cancellationToken);
        }
    }
}