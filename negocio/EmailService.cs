using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient("smtp.mailtrap.io", 2525);
            server.Credentials = new NetworkCredential("0569bacc96eb31", "4a49cb55e21113");
            server.EnableSsl = true;           
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo, string emailRegistro, string codInvitacion)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@sorteo.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<h1>¡Te unieron a un grupo para compartir gastos!</h1> <br> Iniciá sesión con el email " + emailRegistro + " y usa como contraseña el codigo de invitación: " + codInvitacion;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
