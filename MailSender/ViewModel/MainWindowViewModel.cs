using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Interfaces;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        #region Window Title

        /// <summary>
        /// Title of Window
        /// </summary>
        private string _Title = "Mail Sender app";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #region Window Status

        /// <summary>
        /// Status of Window
        /// </summary>
        private string _Status = "Ready to work";
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }        

        #endregion

        #region RecipientsData

        private readonly IRecipientsData _RecipientsData;
        private readonly IMailService _MailService;

        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();

        /// <summary>
        /// Command for update Recipient window area
        /// </summary>
        public ICommand UpdateRecipientsCommand { get; }

        /// <summary>
        /// Command for update Recipient data
        /// </summary>
        public ICommand SaveRecipientCommand { get; }

        private bool CanUpdateRecipientsCommandExecuted() => true;
        private void OnUpdateRecipientsCommandExecuted()
        {
            Recipients.Clear();
            foreach (var recipient in _RecipientsData.GetAll())
                Recipients.Add(recipient);
        }

        /// <summary>
        /// Get Current Recipient
        /// </summary>
        private Recipient _CurrentRecipient;
        public Recipient CurrentRecipient
        {
            get => _CurrentRecipient;
            set => Set(ref _CurrentRecipient, value);
        }
        
        /// <summary>
        /// Main Window View Model
        /// </summary>
        /// <param name="RecipientsData"></param>
        /// <param name="MailService"></param>
        public MainWindowViewModel(IRecipientsData RecipientsData, IMailService MailService)
        {
            UpdateRecipientsCommand = new RelayCommand(OnUpdateRecipientsCommandExecuted, CanUpdateRecipientsCommandExecuted);

            _RecipientsData = RecipientsData;
            _MailService = MailService;
        }

        #endregion
    }
}
