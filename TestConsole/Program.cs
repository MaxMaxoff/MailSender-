using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("toropov@club.info", "Maxim Toropov");
            message.To.Add("maxim.vt@gmail.com");

            message.Subject = "Сообщение от ConsoleApp";
            message.Body = "Текст сообщения";
            message.IsBodyHtml = false;

            SmtpClient client = new SmtpClient("smtp.yandex.ru", 465);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("username@yandex.ru", "password");

            client.Send(message);

            Console.ReadLine();
        }
    }
}
