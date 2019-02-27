using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Infrastructure;
using MailSender.lib.Data;
using MailSender.lib.Data.Context;
using MailSender.lib.Data.EF;
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

            SimpleIoc.Default.Register<IData<Recipient>, EFRecipientsData>();
            SimpleIoc.Default.Register<IData<Server>, EFServersData>();
            SimpleIoc.Default.Register<IData<Sender>, EFSendersData>();
            SimpleIoc.Default.Register<IData<SchedulerTask>, EFSchedulerTasksData>();
            SimpleIoc.Default.Register<IData<Mail>, EFMailsData>();

            if (!SimpleIoc.Default.IsRegistered<MailDatabaseContext>())
                SimpleIoc.Default.Register(() => new MailDatabaseContext());
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