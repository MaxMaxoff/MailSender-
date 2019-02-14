using System.Collections.Generic;
using System.Security;
using MailSender.lib.Interfaces;
using System.Diagnostics;
using System.Threading;

namespace MailSender.Infrastructure
{
    internal class DebugMailService : IMailService
    {
        public IMailSender GetSender(string Address, int Port, bool UseSSL, string Login, SecureString Password)
        {
            return new DebugMailSender(Address, Port, UseSSL, Login, Password);
        }
    }

    internal class DebugMailSender : IMailSender
    {
        private string _Address;
        private int _Port;
        private bool _UseSSL;
        private string _Login;
        private SecureString _Password;

        public DebugMailSender(string Address, int Port, bool UseSSL, string Login, SecureString Password)
        {
            _Address = Address;
            _Port = Port;
            _UseSSL = UseSSL;
            _Login = Login;
            _Password = Password;
        }

        public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            Trace.TraceInformation($"Отправка сообщения через сервер {_Address}:{_Port}  (ssl:{_UseSSL})\r\n" +
                            $"  Login:{_Login}\r\n" +
                            $"  Отправитель:{SenderAddress}\r\n" +
                            $"  Получатель:{RecipientAddress}\r\n" +
                            $"  Тема:{Subject}\r\n" +
                            $"  Сообщение:{Body}\r\n");
        }

        public void SendAsync(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            var thread = new Thread(() => Send(SenderAddress, RecipientAddress, Subject, Body));
            thread.Priority = ThreadPriority.BelowNormal;
            thread.IsBackground = true;
            thread.Start();
        }

        public void Send(string SenderAddress, IEnumerable<string> RecipientAddresses, string Subject, string Body)
        {
            foreach (var recipientAddress in RecipientAddresses)
                Send(SenderAddress, recipientAddress, Subject, Body);
        }

        public void SendAsync(string SenderAddress, IEnumerable<string> RecipientAddresses, string Subject, string Body)
        {
            foreach (var recipientAddress in RecipientAddresses)
                ThreadPool.QueueUserWorkItem(o => Send(SenderAddress, recipientAddress, Subject, Body));
        }

        public void Dispose()
        {
            
        }
    }
}
