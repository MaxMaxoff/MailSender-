using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Data;
using MailSender.lib.Interfaces;

namespace MailSender.ViewModel
{
    public class ServersViewModel : ViewModelBase
    {
        #region ServersData

        private IData<Server> _ServersData;
        //public ObservableCollection<Server> Servers { get; } = new ObservableCollection<Server>();

        private ObservableCollection<Server> _Servers;
        public ObservableCollection<Server> Servers
        {
            get
            {
                if (_Servers != null) return _Servers;
                _Servers = new ObservableCollection<Server>(_ServersData.GetAll());
                return _Servers;
            }
        }

        public ICommand UpdateServersCommand { get; }

        public ICommand SaveServerCommand { get; }

        private bool CanUpdateServersCommandExecuted() => true;
        private void OnUpdateServersCommandExecuted()
        {
            Servers.Clear();
            foreach (var server in _ServersData.GetAll())
                Servers.Add(server);
        }

        /// <summary>
        /// Get Current Server
        /// </summary>
        private Server _CurrentServer;
        public Server CurrentServer
        {
            get => _CurrentServer;
            set => Set(ref _CurrentServer, value);
        }

        /// <summary>
        /// Servers View Model
        /// </summary>
        /// <param name="ServersData"></param>
        public ServersViewModel(IData<Server> ServersData)
        {
            UpdateServersCommand = new RelayCommand(OnUpdateServersCommandExecuted, CanUpdateServersCommandExecuted);

            _ServersData = ServersData;
        }

        #endregion
    }
}
