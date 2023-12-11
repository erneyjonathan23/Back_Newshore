using OP.Prueba.Application.Features.EmailNotificationCommand.Commands.EmailNotificationCommand;
using OP.Prueba.Application.Wrappers;

namespace OP.Prueba.Application.Interfaces
{
    public interface IEmailService
    {
        Task<Response<bool>> NotifyCreationReservation(EmailNotificationCommand request, CancellationToken cancellationToken);
    }
}