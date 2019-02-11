using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Data.InMemory
{
    public class InMemorySchedulerTasksData : ISchedulerTasksData
    {
        private readonly List<SchedulerTask> _SchedulerTasks = new List<SchedulerTask>
        {
            new SchedulerTask{Id = 1, Name = "", Time = DateTime.Now.AddHours(1), Mail = "InMemory Message 1"},
            new SchedulerTask{Id = 2, Name = "", Time = DateTime.Now.AddHours(2), Mail = "InMemory Message 2"},
            new SchedulerTask{Id = 3, Name = "", Time = DateTime.Now.AddHours(3), Mail = "InMemory Message 3"},
        };

        public IEnumerable<SchedulerTask> GetAll()
        {
            return _SchedulerTasks;
        }

        public SchedulerTask GetById(int id)
        {
            return _SchedulerTasks.FirstOrDefault(s => s.Id == id);
        }

        public void AddNew(SchedulerTask newSchedulerTask)
        {
            if (_SchedulerTasks.Contains(newSchedulerTask))
                return;
            newSchedulerTask.Id = _SchedulerTasks.Max(s => s.Id) + 1;
            _SchedulerTasks.Add(newSchedulerTask);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is null)
                return;
            _SchedulerTasks.Remove(item);
        }

        public void SaveChanges()
        {
            
        }
    }
}
