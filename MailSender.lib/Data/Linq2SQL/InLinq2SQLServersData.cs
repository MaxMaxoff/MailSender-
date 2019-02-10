using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.Linq2SQL
{
    public class InLinq2SQLServersData : IServersData
    {
        private MailDataBaseContext _db;

        public InLinq2SQLServersData(MailDataBaseContext DataBaseContext)
        {
            _db = DataBaseContext;
        }

        public void AddNew(Server newServer)
        {
            var server = _db.Server.FirstOrDefault(m => m.Address == newServer.Address);
            if (!(server is null)) return;
            newServer.Id = _db.Server.Max(r => r.Id) + 1;
            _db.Server.InsertOnSubmit(newServer);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.Server.DeleteOnSubmit(item);
        }

        public IEnumerable<Server> GetAll()
        {
            return _db.Server.AsEnumerable();
        }

        public Server GetById(int id)
        {
            return _db.Server.FirstOrDefault(s => s.Id == id);
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}
