using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestMailSender
{
    public class ServerSettings
    {
        private string serverAddress; // = "smtp.yandex.ru";
        private int serverPort; // = 25;

        public string ServerAddress
        {
            get { return serverAddress; }
            set { serverAddress = value; }
        }

        public int ServerPort
        {
            get { return serverPort; }
            set { serverPort = value; }
        }

        public ServerSettings()
        {
            ServerAddress = "smtp.yandex.ru";
            ServerPort = 25;
        }

    }
}
