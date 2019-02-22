using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.Linq2SQL
{
    public class InLinq2SQLRecipientsData : IData<Recipient>
    {
        private MailDataBaseContext _db;

        public InLinq2SQLRecipientsData(MailDataBaseContext DataBaseContext)
        {
            _db = DataBaseContext;
        }

        public void AddNew(Recipient newRecipient)
        {
            var recipient = _db.Recipients.FirstOrDefault(m => m.Address == newRecipient.Address);
            if (!(recipient is null)) return;
            newRecipient.Id = _db.Recipients.Max(r => r.Id) + 1;
            _db.Recipients.InsertOnSubmit(newRecipient);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.Recipients.DeleteOnSubmit(item);
        }

        public IEnumerable<Recipient> GetAll()
        {
            return _db.Recipients.AsEnumerable();
        }

        public Recipient GetById(int id)
        {
            return _db.Recipients.FirstOrDefault(r => r.Id == id);
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}
