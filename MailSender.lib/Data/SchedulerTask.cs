using System;
using System.ComponentModel.DataAnnotations;

namespace MailSender.lib.Data
{
    public class SchedulerTask
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Time { get; set; }
        public virtual MailsList Mails { get; set; }
        public virtual SendingList Recipients { get; set; }
        public virtual Sender Sender { get; set; }
        public virtual Server MailServer { get; set; }
    }
}
