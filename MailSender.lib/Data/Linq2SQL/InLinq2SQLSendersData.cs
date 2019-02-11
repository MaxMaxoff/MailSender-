using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.Linq2SQL
{
    public class InLinq2SQLSendersData : ISendersData
    {
        private MailDataBaseContext _db;

        public InLinq2SQLSendersData(MailDataBaseContext DataBaseContext)
        {
            _db = DataBaseContext;
        }

        public void AddNew(Sender newSender)
        {
            var sender = _db.Server.FirstOrDefault(m => m.Address == newSender.Address);
            if (!(sender is null)) return;
            newSender.Id = _db.Sender.Max(r => r.Id) + 1;
            _db.Sender.InsertOnSubmit(newSender);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.Sender.DeleteOnSubmit(item);
        }

        public IEnumerable<Sender> GetAll()
        {
            return _db.Sender.AsEnumerable();
        }

        public Sender GetById(int id)
        {
            return _db.Sender.FirstOrDefault(s => s.Id == id);
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}
