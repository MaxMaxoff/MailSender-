using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public class Servers
    {
        public static readonly List<Server> Items = new List<Server>
        {
            new Server{Name = "Яндекс", Address = "smtp.yandex.ru", Port = 25, UseSSL = true},
            new Server{Name = "Mail.ru", Address = "smtp.mail.ru", Port = 25, UseSSL = true},
            new Server{Name = "Gmail", Address = "smtp.gmail.com", Port = 25, UseSSL = true},
        };
    }
}
