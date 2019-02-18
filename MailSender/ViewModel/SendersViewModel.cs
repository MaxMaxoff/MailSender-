using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;

namespace MailSender.ViewModel
{
    public class SendersViewModel : ViewModelBase
    {
        #region SendersData

        private IData<Sender> _SendersData;
        //public ObservableCollection<Sender> Senders { get; } = new ObservableCollection<Sender>();

        private ObservableCollection<Sender> _Senders;
        public ObservableCollection<Sender> Senders
        {
            get
            {
                if (_Senders != null) return _Senders;
                _Senders = new ObservableCollection<Sender>(_SendersData.GetAll());
                return _Senders;
            }
        }

        public ICommand UpdateSendersCommand { get; }

        public ICommand SaveSenderCommand { get; }

        private bool CanUpdateSendersCommandExecuted() => true;
        private void OnUpdateSendersCommandExecuted()
        {
            Senders.Clear();
            foreach (var sender in _SendersData.GetAll())
                Senders.Add(sender);
        }

        /// <summary>
        /// Get Current Sender
        /// </summary>
        private Sender _CurrentSender;
        public Sender CurrentSender
        {
            get => _CurrentSender;
            set => Set(ref _CurrentSender, value);
        }

        /// <summary>
        /// Senders View Model
        /// </summary>
        /// <param name="SendersData"></param>
        public SendersViewModel(IData<Sender> SendersData)
        {
            UpdateSendersCommand = new RelayCommand(OnUpdateSendersCommandExecuted, CanUpdateSendersCommandExecuted);

            _SendersData = SendersData;
        }

        #endregion
    }
}
