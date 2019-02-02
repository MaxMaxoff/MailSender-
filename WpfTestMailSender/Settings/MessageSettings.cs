using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestMailSender
{
    public class MessageSettings
    {
        public string messageFrom; // = "Maxim Toropov";
        public string mailFrom; // = "@yandex.ru";
        public string messageTo; // = "@gmail.com";
        public string messageSubject; // = "Subject";
        public string messageBody; // = "Body Message";

        public bool isMessageBodyHTML; // = false;

        //public string MessageFrom
        //{
        //    get { return MessageFrom1; }
        //    set { MessageFrom1 = value; }
        //}

        //public string MailFrom
        //{
        //    get { return mailFrom; }
        //    set { mailFrom = value; }
        //}

        //public string MessageTo
        //{
        //    get { return messageTo; }
        //    set { messageTo = value; }
        //}

        //public string MessageSubject
        //{
        //    get { return messageSubject; }
        //    set { messageSubject = value; }
        //}

        //public string MessageBody
        //{
        //    get { return messageBody; }
        //    set { messageBody = value; }
        //}

        //public bool IsMessageBodyHTML
        //{
        //    get { return isMessageBodyHTML; }
        //    set { isMessageBodyHTML = value; }
        //}
        
        public MessageSettings(string messageFrom, string mailFrom, string messageTo, string messageSubject, string messageBody, bool isMessageBodyHTML)
        {
            this.messageFrom = messageFrom;
            this.mailFrom = mailFrom;
            this.messageTo = messageTo;
            this.messageSubject = messageSubject;
            this.messageBody = messageBody;

            this.isMessageBodyHTML = isMessageBodyHTML;
        }
        
    }
}
