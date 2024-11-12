using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;

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
            email.Body = "<h1>¡Te unieron a un grupo para compartir gastos!</h1> <br> Si aun no estas registrado o no has cambiado la contraseña, iniciá sesión con el email " + emailRegistro + " y usa como contraseña el código de invitación: " + codInvitacion +
                "<br> Si ya te habías unido a un grupo y no recordas el código de invitación ingresá a 'Olvide mi contraseña' al iniciar sesión." ;
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

        public void EnviarCorreoConfirmacion(string emailParticipante, string codInvitacionPass)
        {
            try
            {
                // Definir el mensaje de correo
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("progratresmarjuanmartin@gmail.com");
                mensaje.To.Add(new MailAddress(emailParticipante));
                mensaje.Subject = "¡Te unieron a un grupo de gastos!";
                mensaje.Body = $"<h1>¡Hola, {emailParticipante}!</h1>" +
                               $"<p> Te invitaron a que te unas a un grupo de gestión de gastos. Si nunca te has registrado ni cambiado la contraseña, podes ingresar con el email {emailParticipante} y el código de invitacion {codInvitacionPass} como contraseña y participar en la división de gastos con tus amigos.</p>" +
                               $"<p> Si ya te habías unido a un grupo, nunca cambiaste la contraseña y no recordás el primer código de inivitación, podes elegir desde Iniciar Sesión 'Olvidé mi contraseña' y generar una nueva.</p>" +
                               $"<p> Te esperamos pronto en la app, no olvides cambiar tu password si sigue siendo el código de invitación. ¡Gracias por elegirnos!</p>" +
                               $"<br/>" +
                               $"<p>Atentamente,</p>" +
                               $"<p>App Gestor de Gastos TweentyB</p>";
                mensaje.IsBodyHtml = true;
                // Configurar el cliente SMTP para Gmail
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);  //el servidor smtp OJO, SOLO FUNCIONA CON ESE PUERTO Y NO FUNCIONA CON NINGUNO MAS
                smtpClient.Credentials = new NetworkCredential("progratresmarjuanmartin@gmail.com", "ndgo fttt cyio rrrs"); // esta es la api key que tenemos que usar
                smtpClient.EnableSsl = true;
                // Enviar el mensaje
                smtpClient.Send(mensaje);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al enviar el correo electrónico: " + ex.Message);
            }
        }
    }
}
