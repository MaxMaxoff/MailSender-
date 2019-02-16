using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Infrastructure; //SimpleIoc.Default.Register<IMailService, DebugMailService>();
using MailSender.lib; //SimpleIoc.Default.Register<IMailService, MailService>();
using MailSender.lib.Data.InMemory;
using MailSender.lib.Data.Linq2SQL;
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
            SimpleIoc.Default.Register<IRecipientsData, InMemoryRecipientsData>();
            SimpleIoc.Default.Register<IServersData, InMemoryServersData>();
            SimpleIoc.Default.Register<ISendersData, InMemorySendersData>();
            SimpleIoc.Default.Register<ISchedulerTasksData, InMemorySchedulerTasksData>();
            
            // InLinq2SQL for real data
            //SimpleIoc.Default.Register<IRecipientsData, InLinq2SQLRecipientsData>();
            //SimpleIoc.Default.Register<IServersData, InLinq2SQLServersData>();
            //SimpleIoc.Default.Register<ISendersData, InLinq2SQLSendersData>();
            //SimpleIoc.Default.Register<ISchedulerTasksData, InLinq2SQLSchedulerTasksData>();
            
            if (!SimpleIoc.Default.IsRegistered<MailDataBaseContext>())
                SimpleIoc.Default.Register(() => new MailDataBaseContext());
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