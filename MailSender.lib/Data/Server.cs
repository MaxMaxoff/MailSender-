using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public class Server
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
    }
}
