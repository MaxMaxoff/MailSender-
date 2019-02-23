using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data
{
    public class Recipients : IData<Recipient>
    {
        private readonly List<Recipient> _Recipients = new List<Recipient>
        {
            new Recipient{Id = 0, Name = "Иванов", Address = "ivanov@yandex.ru"},
            new Recipient{Id = 1, Name = "Петров", Address = "petrov@yandex.ru"},
            new Recipient{Id = 2, Name = "Сидоров", Address = "sidorov@yandex.ru"},
        };

        public IEnumerable<Recipient> GetAll()
        {
            return _Recipients;
        }

        public Recipient GetById(int id)
        {
            return _Recipients.FirstOrDefault(r => r.Id == id);
        }

        public void AddNew(Recipient newRecipient)
        {
            if (_Recipients.Contains(newRecipient))
                return;
            newRecipient.Id = _Recipients.Max(r => r.Id) + 1;
            _Recipients.Add(newRecipient);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null)
                return;
            _Recipients.Remove(item);
        }

        public void SaveChanges()
        {
            
        }
    }
}
