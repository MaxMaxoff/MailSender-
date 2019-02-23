using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public class Mails
    {
        public static readonly List<Mail> Items = new List<Mail>
        {
            new Mail{Subject = "Mail Subject 1", Body = "Mail Body 1"},
            new Mail{Subject = "Mail Subject 2", Body = "Mail Body 2"},
            new Mail{Subject = "Mail Subject 3", Body = "Mail Body 3"},
        };
    }
}
