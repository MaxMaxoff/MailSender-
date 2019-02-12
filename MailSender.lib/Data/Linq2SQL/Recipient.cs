using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.Linq2SQL
{
    public partial class Recipient : IDataErrorInfo
    {
        string IDataErrorInfo.Error => string.Empty;

        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {
                    case nameof(Id): break;

                    case nameof(Name):
                        if (Name is null) return "Имя не может быть пустым";
                        if (Name.Length < 2) return "Имя не может быть короче 2 символов";
                        break;

                    case nameof(Address):
                        if (Address is null) return "Email не может быть пустым";
                        try {
                            var addr = new System.Net.Mail.MailAddress(Address);
                            if (addr.Address != Address) return "Некорректный email адрес";
                        }
                        catch {
                            return "Введен некорректный email адрес";
                        }
                        break;
                }

                return string.Empty;
            }
        }

    }
}
