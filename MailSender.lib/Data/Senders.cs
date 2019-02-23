using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public class Senders
    {
        public static readonly List<Sender> Items = new List<Sender>
        {
            new Sender{Name = "Иванов", Address = "ivanov@yandex.ru"},
            new Sender{Name = "Петров", Address = "petrov@yandex.ru"},
            new Sender{Name = "Сидоров", Address = "sidorov@yandex.ru"},
        };
    }
}
