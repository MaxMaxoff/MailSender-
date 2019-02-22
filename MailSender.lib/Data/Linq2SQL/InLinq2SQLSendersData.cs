using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.Linq2SQL
{
    public class InLinq2SQLSendersData : IData<Sender>
    {
        private MailDataBaseContext _db;

        public InLinq2SQLSendersData(MailDataBaseContext DataBaseContext)
        {
            _db = DataBaseContext;
        }

        public void AddNew(Sender newSender)
        {
            var sender = _db.Senders.FirstOrDefault(m => m.Address == newSender.Address);
            if (!(sender is null)) return;
            newSender.Id = _db.Senders.Max(r => r.Id) + 1;
            _db.Senders.InsertOnSubmit(newSender);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.Senders.DeleteOnSubmit(item);
        }

        public IEnumerable<Sender> GetAll()
        {
            return _db.Senders.AsEnumerable();
        }

        public Sender GetById(int id)
        {
            return _db.Senders.FirstOrDefault(s => s.Id == id);
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}
