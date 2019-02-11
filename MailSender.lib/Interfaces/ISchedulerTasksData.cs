using System.Collections.Generic;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib.Interfaces
{
    public interface ISchedulerTasksData
    {
        IEnumerable<SchedulerTask> GetAll();

        SchedulerTask GetById(int id);

        void AddNew(SchedulerTask newSchedulerTask);

        void Delete(int id);

        void SaveChanges();
    }
}
