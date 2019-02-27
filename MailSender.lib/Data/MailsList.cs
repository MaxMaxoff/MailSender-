using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailSender.lib.Data
{
    public class MailsList
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<Mail> Mails { get; set; }
    }
}
