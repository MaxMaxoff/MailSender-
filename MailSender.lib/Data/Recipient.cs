using System.ComponentModel.DataAnnotations;

namespace MailSender.lib.Data
{
    public class Recipient
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
