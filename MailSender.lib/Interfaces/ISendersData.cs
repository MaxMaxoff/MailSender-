using System.Collections.Generic;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib.Interfaces
{
    public interface ISendersData
    {
        IEnumerable<Sender> GetAll();

        Sender GetById(int id);

        void AddNew(Sender newSender);

        void Delete(int id);

        void SaveChanges();
    }
}
