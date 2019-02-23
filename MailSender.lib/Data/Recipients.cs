using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public class Recipients
    {
        public static readonly List<Recipient> Items = new List<Recipient>
        {
            new Recipient{Name = "Иванов", Address = "ivanov@yandex.ru"},
            new Recipient{Name = "Петров", Address = "petrov@yandex.ru"},
            new Recipient{Name = "Сидоров", Address = "sidorov@yandex.ru"},
        };
    }
}
