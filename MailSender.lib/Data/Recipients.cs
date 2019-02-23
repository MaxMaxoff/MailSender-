using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public class Recipients
    {
        private readonly List<Recipient> Items = new List<Recipient>
        {
            new Recipient{Id = 0, Name = "Иванов", Address = "ivanov@yandex.ru"},
            new Recipient{Id = 1, Name = "Петров", Address = "petrov@yandex.ru"},
            new Recipient{Id = 2, Name = "Сидоров", Address = "sidorov@yandex.ru"},
        };
    }
}
