using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.Linq2SQL
{
    public class InLinq2SQLRecipientsData : IRecipientsData
    {
        private MailDataBaseContext _db;

        public InLinq2SQLRecipientsData(MailDataBaseContext DataBaseContext)
        {
            _db = DataBaseContext;
        }

        public void AddNew(Recipient newRecipient)
        {
            var recipient = _db.Recipient.FirstOrDefault(m => m.Address == newRecipient.Address);
            if (!(recipient is null)) return;
            newRecipient.Id = _db.Recipient.Max(r => r.Id) + 1;
            _db.Recipient.InsertOnSubmit(newRecipient);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.Recipient.DeleteOnSubmit(item);
        }

        public IEnumerable<Recipient> GetAll()
        {
            return _db.Recipient.AsEnumerable();
        }

        public Recipient GetById(int id)
        {
            return _db.Recipient.FirstOrDefault(r => r.Id == id);
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}
