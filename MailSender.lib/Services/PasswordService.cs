using System;
using System.Linq;

namespace MailSender.lib.Services
{
    public static class PasswordService
    {
        public static string Encrypt(string str, int key = 1)
        {
            if(str is null) throw new ArgumentNullException(nameof(str));
            return new string(str.Select(c => (char)(c + key)).ToArray());
        }

        public static string Decrypt(string str, int key = 1)
        {
            if(str is null) throw new ArgumentNullException(nameof(str));
            return new string(str.Select(c => (char)(c - key)).ToArray());
        }
    }
}
