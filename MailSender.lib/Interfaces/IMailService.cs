using System;
using System.Collections.Generic;
using System.Security;

namespace MailSender.lib.Interfaces
{
    public interface IMailService
    {
        IMailSender GetSender(string Address, int Port, bool UseSSL, string Login, SecureString Password);
    }

    public interface IMailSender : IDisposable
    {
        void Send(string SenderAddress, string RecipientAddress, string Subject, string Body);

        void SendAsync(string SenderAddress, string RecipientAddress, string Subject, string Body);

        void Send(string SenderAddress, IEnumerable<string> RecipientAddresses, string Subject, string Body);

        void SendAsync(string SenderAddress, IEnumerable<string> RecipientAddresses, string Subject, string Body);
    }
}
