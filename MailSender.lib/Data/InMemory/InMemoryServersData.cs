using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.InMemory
{
    public class InMemoryServersData : IData<Server>
    {
        private readonly List<Server> _Servers = new List<Server>
        {
            new Server{Id = 1, Name = "Яндекс", Address = "smtp.yandex.ru", Port = 25, UseSSL = true},
            new Server{Id = 2, Name = "Mail.ru", Address = "smtp.mail.ru", Port = 25, UseSSL = true},
            new Server{Id = 3, Name = "Gmail", Address = "smtp.gmail.com", Port = 25, UseSSL = true},
        };

        public IEnumerable<Server> GetAll()
        {
            return _Servers;
        }

        public Server GetById(int id)
        {
            return _Servers.FirstOrDefault(s => s.Id == id);
        }

        public void AddNew(Server newServer)
        {
            if(_Servers.Contains(newServer))
                return;
            newServer.Id = _Servers.Max(s => s.Id) + 1;
            _Servers.Add(newServer);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if(item is null)
                return;
            _Servers.Remove(item);
        }

        public void SaveChanges()
        {
            
        }
    }
}
