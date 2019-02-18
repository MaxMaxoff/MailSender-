using System.ComponentModel;

namespace MailSender.lib.Data.Linq2SQL
{
    /// <summary>
    /// Recipients for validation
    /// </summary>
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
