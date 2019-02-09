using System.Collections.Generic;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib.Interfaces
{
    public interface IRecipientsData
    {
        IEnumerable<Recipient> GetAll();

        Recipient GetById(int id);
        
        void AddNew(Recipient newRecipient);
        
        void Delete(int id);
        
        void SaveChanges();

    }
}
