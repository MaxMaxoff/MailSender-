using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Data.Debug
{
    public static class Servers
    {
        public static List<Server> Items { get; } = new List<Server>
        {
            new Server {Id = 1, Name = "Яндекс", Address = "smtp.yandex.ru", Port = 25, UseSSL = true},
            new Server {Id = 2, Name = "Mail.ru", Address = "smtp.mail.ru", Port = 25, UseSSL = true},
            new Server {Id = 3, Name = "Gmail", Address = "smtp.gmail.com", Port = 25, UseSSL = true},
        };
    }

    public class Server
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }

    }
}
