using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Data;
using MailSender.lib.Interfaces;

namespace MailSender.ViewModel
{
    public class SchedulerTasksViewModel : ViewModelBase
    {
        #region SchedulerTasksData

        private IData<SchedulerTask> _SchedulerTasksData;
        //public ObservableCollection<SchedulerTask> SchedulerTasks { get; } = new ObservableCollection<SchedulerTask>();
        
        private ObservableCollection<SchedulerTask> _SchedulerTasks;
        public ObservableCollection<SchedulerTask> SchedulerTasks
        {
            get
            {
                if (_SchedulerTasks != null) return _SchedulerTasks;
                _SchedulerTasks = new ObservableCollection<SchedulerTask>(_SchedulerTasksData.GetAll());
                return _SchedulerTasks;
            }
        }

        public ICommand UpdateSchedulerTasksCommand { get; }

        public ICommand SaveSchedulerTaskCommand { get; }

        private bool CanUpdateSchedulerTasksCommandExecuted() => true;
        private void OnUpdateSchedulerTasksCommandExecuted()
        {
            SchedulerTasks.Clear();
            foreach (var schedulerTask in _SchedulerTasksData.GetAll())
                SchedulerTasks.Add(schedulerTask);
        }

        /// <summary>
        /// Get Current SchedulerTask
        /// </summary>
        private SchedulerTask _CurrentSchedulerTask;
        public SchedulerTask CurrentSchedulerTask
        {
            get => _CurrentSchedulerTask;
            set => Set(ref _CurrentSchedulerTask, value);
        }

        /// <summary>
        /// SchedulerTasks View Model
        /// </summary>
        /// <param name="SchedulerTasksData"></param>
        public SchedulerTasksViewModel(IData<SchedulerTask> SchedulerTasksData)
        {
            UpdateSchedulerTasksCommand = new RelayCommand(OnUpdateSchedulerTasksCommandExecuted, CanUpdateSchedulerTasksCommandExecuted);

            _SchedulerTasksData = SchedulerTasksData;
        }

        #endregion
    }
}
