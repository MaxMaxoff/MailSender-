using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;
using PasswordServiceLib;

namespace MailSender.lib.Data.InMemory
{
    public class InMemorySendersData : ISendersData
    {
        private readonly List<Sender> _Senders = new List<Sender>
        {
            new Sender{Id = 1, Name = "Иванов", Address = "ivanov@yandex.ru", Password = PasswordEncoder.Encrypt("Password1")},
            new Sender{Id = 2, Name = "Петров", Address = "petrov@yandex.ru", Password = PasswordEncoder.Encrypt("Password2")},
            new Sender{Id = 3, Name = "Сидоров", Address = "sidorov@yandex.ru", Password = PasswordEncoder.Encrypt("Password3")},
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
            var sender = GetById(id);
            if (sender is null)
                return;
            _Senders.Remove(sender);
        }

        public void SaveChanges()
        {
            
        }
    }
}
