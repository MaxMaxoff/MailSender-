using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.Linq2SQL
{
    public class InLinq2SQLSchedulerTasksData : ISchedulerTasksData
    {
        private MailDataBaseContext _db;

        public InLinq2SQLSchedulerTasksData(MailDataBaseContext DataBaseContext)
        {
            _db = DataBaseContext;
        }

        public void AddNew(SchedulerTask newSchedulerTask)
        {
            newSchedulerTask.Id = _db.SchedulerTask.Max(r => r.Id) + 1;
            _db.SchedulerTask.InsertOnSubmit(newSchedulerTask);

        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _db.SchedulerTask.DeleteOnSubmit(item);
        }

        public IEnumerable<SchedulerTask> GetAll()
        {
            return _db.SchedulerTask.AsEnumerable();
        }

        public SchedulerTask GetById(int id)
        {
            return _db.SchedulerTask.FirstOrDefault(s => s.Id == id);
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}
