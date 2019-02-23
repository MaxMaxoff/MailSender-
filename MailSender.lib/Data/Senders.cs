using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Interfaces;
using MailSender.lib.Services;

namespace MailSender.lib.Data
{
    public class Senders : IData<Sender>
    {
        private readonly List<Sender> _Senders = new List<Sender>
        {
            new Sender{Id = 1, Name = "Иванов", Address = "ivanov@yandex.ru"},
            new Sender{Id = 2, Name = "Петров", Address = "petrov@yandex.ru"},
            new Sender{Id = 3, Name = "Сидоров", Address = "sidorov@yandex.ru"},
        };

        public IEnumerable<Sender> GetAll()
        {
            return _Senders;
        }

        public Sender GetById(int id)
        {
            return _Senders.FirstOrDefault(s => s.Id == id);
        }

        public void AddNew(Sender newSender)
        {
            if(_Senders.Contains(newSender))
                return;
            newSender.Id = _Senders.Max(s => s.Id) + 1;
            _Senders.Add(newSender);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null)
                return;
            _Senders.Remove(item);
        }

        public void SaveChanges()
        {
            
        }
    }
}
