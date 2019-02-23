using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public class Servers
    {
        private readonly List<Server> Items = new List<Server>
        {
            new Server{Id = 1, Name = "Яндекс", Address = "smtp.yandex.ru", Port = 25, UseSSL = true},
            new Server{Id = 2, Name = "Mail.ru", Address = "smtp.mail.ru", Port = 25, UseSSL = true},
            new Server{Id = 3, Name = "Gmail", Address = "smtp.gmail.com", Port = 25, UseSSL = true},
        };
    }
}
