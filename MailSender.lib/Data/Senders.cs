using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public class Senders
    {
        private readonly List<Sender> Items = new List<Sender>
        {
            new Sender{Id = 1, Name = "Иванов", Address = "ivanov@yandex.ru"},
            new Sender{Id = 2, Name = "Петров", Address = "petrov@yandex.ru"},
            new Sender{Id = 3, Name = "Сидоров", Address = "sidorov@yandex.ru"},
        };
    }
}
