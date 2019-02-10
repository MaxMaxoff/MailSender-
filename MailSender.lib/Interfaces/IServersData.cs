using System.Collections.Generic;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib.Interfaces
{
    public interface IServersData
    {
        IEnumerable<Server> GetAll();

        Server GetById(int id);

        void AddNew(Server newServer);
        
        void Delete(int id);
        
        void SaveChanges();

    }
}
