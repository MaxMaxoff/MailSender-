using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestMailSender
{
    public class MessageSettings
    {
        private string messageFrom; // = "Maxim Toropov";
        private string mailFrom; // = "@yandex.ru";
        private string messageTo; // = "@gmail.com";
        private string messageSubject; // = "Subject";
        private string messageBody; // = "Body Message";

        private bool isMessageBodyHTML; // = false;

        public string MessageFrom
        {
            get { return messageFrom; }
            set { messageFrom = value; }
        }

        public string MailFrom
        {
            get { return mailFrom; }
            set { mailFrom = value; }
        }

        public string MessageTo
        {
            get { return messageTo; }
            set { messageTo = value; }
        }

        public string MessageSubject
        {
            get { return messageSubject; }
            set { messageSubject = value; }
        }

        public string MessageBody
        {
            get { return messageBody; }
            set { messageBody = value; }
        }

        public bool IsMessageBodyHTML
        {
            get { return isMessageBodyHTML; }
            set { isMessageBodyHTML = value; }
        }

        public MessageSettings(string messageFrom, string mailFrom, string messageTo, string messageSubject, string messageBody, bool isMessageBodyHTML)
        {
            MessageFrom = messageFrom;
            MailFrom = mailFrom;
            MessageTo = messageTo;
            MessageSubject = messageSubject;
            MessageBody = messageBody;

            IsMessageBodyHTML = isMessageBodyHTML;
        }
        
    }
}
