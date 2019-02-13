using System.Collections.Generic;
using MailSender.lib.Services;

namespace MailSender.lib.Data.DebugData
{
    public static class Senders
    {
        public static List<Sender> Items { get; } = new List<Sender>
        {
            new Sender{Id = 1, Name = "Иванов", Address = "ivanov@yandex.ru", Password = PasswordService.Encrypt("Password1")},
            new Sender{Id = 2, Name = "Петров", Address = "petrov@yandex.ru", Password = PasswordService.Encrypt("Password2")},
            new Sender{Id = 3, Name = "Сидоров", Address = "sidorov@yandex.ru", Password = PasswordService.Encrypt("Password3")},
        };
    }

    public class Sender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
