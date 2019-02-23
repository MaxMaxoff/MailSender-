using System;
using System.ComponentModel.DataAnnotations;

namespace MailSender.lib.Data
{
    public class Mail
    {
        public int Id { get; set; }

        [Required]
        public String Subject { get; set; }

        [Required]
        public string Body { get; set; }
    }
}
