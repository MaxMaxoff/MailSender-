using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public class Mails
    {
        private readonly List<Mail> Items = new List<Mail>
        {
            new Mail{Id = 1, Subject = "Mail Subject 1", Body = "Mail Body 1"},
            new Mail{Id = 2, Subject = "Mail Subject 2", Body = "Mail Body 2"},
            new Mail{Id = 3, Subject = "Mail Subject 3", Body = "Mail Body 3"},
        };
    }
}
