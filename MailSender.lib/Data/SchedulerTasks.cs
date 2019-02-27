using System;
using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public class SchedulerTasks
    {
        public static readonly List<SchedulerTask> Items = new List<SchedulerTask>
        {
            new SchedulerTask{Name = "Task 1", Time = DateTime.Now.AddHours(1)},
            new SchedulerTask{Name = "Task 2", Time = DateTime.Now.AddHours(2)},
            new SchedulerTask{Name = "Task 3", Time = DateTime.Now.AddHours(3)},
        };
    }
}
