using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IRecipientsData _RecipientsData;

        private string _Title = "Mail Sender app";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Ready to work";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        private ObservableCollection<Recipient> _Recipients;

        public ObservableCollection<Recipient> Recipients
        {
            get
            {
                if (_Recipients != null) return _Recipients;
                _Recipients = new ObservableCollection<Recipient>(_RecipientsData.GetAll());
                return _Recipients;
            }
        }

        public MainWindowViewModel(IRecipientsData RecipientsData)
        {
            _RecipientsData = RecipientsData;
        }
    }
}
