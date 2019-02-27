using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public class SendingList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Recipient> Recipients { get; set; }
    }}
