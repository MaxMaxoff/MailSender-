using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Data.Debug
{
    public static class SchedulerTasks
    {
        public static List<SchedulerTask> Items { get; } = new List<SchedulerTask>
        {
            new SchedulerTask{Id = 1, Name = "", Time = DateTime.Now.AddHours(1), Mail = "Mail 1"},
            new SchedulerTask{Id = 2, Name = "", Time = DateTime.Now.AddHours(2), Mail = "Mail 2"},
            new SchedulerTask{Id = 3, Name = "", Time = DateTime.Now.AddHours(3), Mail = "Mail 3"},
        };
    }

    public class SchedulerTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Mail { get; set; }
    }
}
