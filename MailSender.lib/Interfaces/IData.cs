using System.Collections.Generic;

namespace MailSender.lib.Interfaces
{
    public interface IData<TItem>
    {
        IEnumerable<TItem> GetAll();

        TItem GetById(int id);

        void AddNew(TItem newTItem);

        void Delete(int id);

        void SaveChanges();
    }
}
