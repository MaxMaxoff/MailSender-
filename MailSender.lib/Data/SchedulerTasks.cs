using System;
using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public class SchedulerTasks
    {
        private readonly List<SchedulerTask> Items = new List<SchedulerTask>
        {
            new SchedulerTask{Id = 1, Name = "", Time = DateTime.Now.AddHours(1)},
            new SchedulerTask{Id = 2, Name = "", Time = DateTime.Now.AddHours(2)},
            new SchedulerTask{Id = 3, Name = "", Time = DateTime.Now.AddHours(3)},
        };
    }
}
