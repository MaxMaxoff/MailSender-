using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace WpfTestMailSender
{
    public class EmailSendServiceClass
    {
        public static void SendMessage(MailMessage message, string user_name, SecureString user_password)
        {
            ServerSettings serverSettings = new ServerSettings();

            using (SmtpClient client = new SmtpClient(serverSettings.ServerAddress, serverSettings.ServerPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(user_name, user_password);

                client.Send(message);
            }
        }
    }
}
