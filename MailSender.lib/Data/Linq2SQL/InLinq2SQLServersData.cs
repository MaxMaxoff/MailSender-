using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.Linq2SQL
{
    public class InLinq2SQLServersData : IData<Server>
    {
        private MailDataBaseContext _db;

        public InLinq2SQLServersData(MailDataBaseContext DataBaseContext)
        {
            _db = DataBaseContext;
        }

        public void AddNew(Server newServer)
        {
            var server = _db.Servers.FirstOrDefault(m => m.Address == newServer.Address);
            if (!(server is null)) return;
            newServer.Id = _db.Servers.Max(r => r.Id) + 1;
            _db.Servers.InsertOnSubmit(newServer);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.Servers.DeleteOnSubmit(item);
        }

        public IEnumerable<Server> GetAll()
        {
            return _db.Servers.AsEnumerable();
        }

        public Server GetById(int id)
        {
            return _db.Servers.FirstOrDefault(s => s.Id == id);
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}
