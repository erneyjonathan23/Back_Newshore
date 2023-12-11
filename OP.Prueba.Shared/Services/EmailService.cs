using Microsoft.Extensions.Configuration;
using NPOI.POIFS.Crypt.Dsig;
using OP.Prueba.Application.Features.EmailNotificationCommand.Commands.EmailNotificationCommand;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using System.Net;
using System.Net.Mail;

namespace OP.Prueba.Shared.Services
{
    public class EmailService : IEmailService
    {
        IConfiguration configuration;
        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Response<bool>> NotifyCreationReservation(EmailNotificationCommand request, CancellationToken cancellationToken)
        {
            string tittle = "Creacion de reservación.";
            string message = $"<!DOCTYPE html><html lang='en'><head><meta charset='utf-8'><meta http-equiv='X-UA-Compatible' content='IE=edge'><meta name='viewport' content='width=device-width, initial-scale=1'><title>Notificacion</title><link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css'integrity='sha512-dTfge/zgoMYpP7QbHy4gWMEGsbsdZeCXz7irItjcC3sPUFtf0kuFbDz/ixG7ArTxmDjLXDmezHubeNikyKGVyQ=='crossorigin='anonymous'></head><body><div class='container'><div class='row'> <br /> <br /><h3 style='background:#0b3f64; color: white; padding: 10px; font-family: Tahoma;'>Se ha creado una reservación!</h3><ul class='list-group'><li class='list-group-item'><h3>Numero de reserva: {request.IdReserva}</h3><h3> {request.NombreCompleto} </h3><a href='https://newshore-air.azurewebsites.net/reservation/form/{request.IdReserva}/view'>Consultar reserva</a></li></ul></div></div><script src='https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js'></script><script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js'integrity='sha512-K1qjQ+NcF2TYO/eI3M6v8EiNYZfA95pQumfvcVrTHtwQVDG+aHRqLi/ETn2uB+1JqwYqVG3LIvdm9lj6imS/pQ=='crossorigin='anonymous'></script></body></html>";
            SendEmailWithParameters(message, tittle, request.Email);
            return new Response<bool>()
            {
                Message = "Se ha enviado el correo exitosamente!",
                Data = true,
                Succeeded = true
            };
        }

        private void SendEmailWithParameters(string message, string tittle, string sendTo)
        {
            MailMessage mail = new MailMessage();
            String usermail = this.configuration["usuario"];
            String passwordmail = this.configuration["password"];

            mail.From = new MailAddress(usermail);
            mail.To.Add(new MailAddress(sendTo));
            mail.Subject = tittle;
            mail.Body = message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            String smtpserver = this.configuration["host"];
            int port = int.Parse(this.configuration["port"]);
            bool ssl = bool.Parse(this.configuration["ssl"]);
            bool defaultcreadentials = bool.Parse(this.configuration["defaultcredentials"]);

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = smtpserver;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
            smtpClient.UseDefaultCredentials = defaultcreadentials;

            NetworkCredential usercredential = new NetworkCredential(usermail, passwordmail);
            smtpClient.Credentials = usercredential;
            smtpClient.Send(mail);
        }
    }
}
