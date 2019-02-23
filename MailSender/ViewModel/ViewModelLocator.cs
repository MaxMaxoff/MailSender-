using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Infrastructure;
using MailSender.lib.Data;
using MailSender.lib.Interfaces;

namespace MailSender.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<ServersViewModel>();
            SimpleIoc.Default.Register<SendersViewModel>();
            SimpleIoc.Default.Register<SchedulerTasksViewModel>();

            SimpleIoc.Default.Register<IMailService, DebugMailService>();
            //SimpleIoc.Default.Register<IMailService, MailService>();

            // InMemory for Debug
            SimpleIoc.Default.Register<Recipients>();
            SimpleIoc.Default.Register<Servers>();
            SimpleIoc.Default.Register<Senders>();
            SimpleIoc.Default.Register<SchedulerTasks>();
            SimpleIoc.Default.Register<Mails>();

            //if (!SimpleIoc.Default.IsRegistered<MailDataBaseContext>())
            //    SimpleIoc.Default.Register(() => new MailDataBaseContext());
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        public ServersViewModel ServersModel => ServiceLocator.Current.GetInstance<ServersViewModel>();
        public SendersViewModel SendersModel => ServiceLocator.Current.GetInstance<SendersViewModel>();
        public SchedulerTasksViewModel SchedulerTasksModel => ServiceLocator.Current.GetInstance<SchedulerTasksViewModel>();
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}