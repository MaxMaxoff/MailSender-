﻿using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Threading;
using MailSender.lib.Interfaces;

namespace MailSender.lib
{
    public class MailService : IMailService
    {
        public IMailSender GetSender(string Address, int Port, bool UseSSL, string Login, SecureString Password)
        {
            return new MailSender(Address, Port, UseSSL, Login, Password);
        }
    }

    internal class MailSender : IMailSender
    {
        private readonly SmtpClient _Client;

        public MailSender(string Address, int Port, bool UseSSL, string Login, SecureString Password)
        {
            _Client = new SmtpClient(Address, Port)
            {
                Credentials = new NetworkCredential(Login, Password),
                EnableSsl = UseSSL
            };
        }

        public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            using (var msg = new MailMessage(SenderAddress, RecipientAddress, Subject, Body))
            _Client.Send(msg);
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
            _Client.Dispose();
        }
    }
}
