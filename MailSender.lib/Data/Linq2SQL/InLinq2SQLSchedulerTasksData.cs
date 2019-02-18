using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.Linq2SQL
{
    public class InLinq2SQLSchedulerTasksData : IData<SchedulerTask>
    {
        private MailDataBaseContext _db;

        public InLinq2SQLSchedulerTasksData(MailDataBaseContext DataBaseContext)
        {
            _db = DataBaseContext;
        }

        public void AddNew(SchedulerTask newSchedulerTask)
        {
            newSchedulerTask.Id = _db.SchedulerTasks.Max(r => r.Id) + 1;
            _db.SchedulerTasks.InsertOnSubmit(newSchedulerTask);

        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.SchedulerTasks.DeleteOnSubmit(item);
        }

        public IEnumerable<SchedulerTask> GetAll()
        {
            return _db.SchedulerTasks.AsEnumerable();
        }

        public SchedulerTask GetById(int id)
        {
            return _db.SchedulerTasks.FirstOrDefault(s => s.Id == id);
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}
