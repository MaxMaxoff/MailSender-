using System;

namespace MailSender.lib.Data
{
    public class SchedulerTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Mail { get; set; }
    }
}
