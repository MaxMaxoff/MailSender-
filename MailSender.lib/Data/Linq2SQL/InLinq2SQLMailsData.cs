using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.Linq2SQL
{
    public class InLinq2SQLMailsData : IData<Mail>
    {
        private MailDataBaseContext _db;

        public InLinq2SQLMailsData(MailDataBaseContext DataBaseContext)
        {
            _db = DataBaseContext;
        }

        public void AddNew(Mail newMail)
        {
            newMail.Id = _db.Mails.Max(r => r.Id) + 1;
            _db.Mails.InsertOnSubmit(newMail);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.Mails.DeleteOnSubmit(item);
        }

        public IEnumerable<Mail> GetAll()
        {
            return _db.Mails.AsEnumerable();
        }

        public Mail GetById(int id)
        {
            return _db.Mails.FirstOrDefault(r => r.Id == id);
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}
