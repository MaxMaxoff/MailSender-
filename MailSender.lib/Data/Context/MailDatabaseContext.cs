using System.Data.Entity;
using MailSender.lib.Migrations;

namespace MailSender.lib.Data.Context
{
    public class MailDatabaseContext : DbContext
    {
        static MailDatabaseContext()
        {
            #region drop db

            // create if not exist
            //Database.SetInitializer(new CreateDatabaseIfNotExists<MailDatabaseContext>());

            // drop and create again always
            //Database.SetInitializer(new DropCreateDatabaseAlways<MailDatabaseContext>());

            // drop and create again if model db changed
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MailDatabaseContext>());

            #endregion

            #region update db without drop

            // update db to latest version
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MailDatabaseContext, Configuration>());

            #endregion
        }

        public MailDatabaseContext() : base("name=MailDatabaseContext") { }

        //public MailDatabaseContext(string ConnectionStr) : base(ConnectionStr) { }

        public DbSet<Mail> Mails { get; set; }

        public DbSet<MailsList> MailsLists { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<SendingList> SendingLists { get; set; }

        public DbSet<SchedulerTask> SchedulerTasks { get; set; }

        public DbSet<Server> Servers { get; set; }
    }
}
