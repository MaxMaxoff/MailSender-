using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data
{
    public class Mails : IData<Mail>
    {
        private readonly List<Mail> _Mails = new List<Mail>
        {
            new Mail{Id = 1, Subject = "Mail Subject 1", Body = "Mail Body 1"},
            new Mail{Id = 2, Subject = "Mail Subject 2", Body = "Mail Body 2"},
            new Mail{Id = 3, Subject = "Mail Subject 3", Body = "Mail Body 3"},
        };


        public IEnumerable<Mail> GetAll()
        {
            return _Mails;
        }

        public Mail GetById(int id)
        {
            return _Mails.FirstOrDefault(m => m.Id == id);
        }

        public void AddNew(Mail newMail)
        {
            if(_Mails.Contains(newMail))
                return;
            newMail.Id = _Mails.Max(s => s.Id) + 1;
            _Mails.Add(newMail);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null)
                return;
            _Mails.Remove(item);
        }

        public void SaveChanges()
        {
            
        }
    }
}
