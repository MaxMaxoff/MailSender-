using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public class Server
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public int Port { get; set; }
        public bool UseSSL { get; set; }
        public string UserName { get; set; }
        public SecureString Password { get; set; }
    }
}
