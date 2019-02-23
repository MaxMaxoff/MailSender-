using System.Linq;
using MailSender.lib.Data;
using MailSender.lib.Data.Context;
using System.Data.Entity.Migrations;

namespace MailSender.lib.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MailDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MailDatabaseContext context)
        {
            //"\r\n(41,10) : error 3004:
            //Problem in mapping fragments starting at line 41:No mapping specified for properties Server.Password in Set Servers.\r\n
            //An Entity with Key (PK) will not round-trip when:\r\n
            //Entity is type [MailSender.lib.Data.Context.Server]\r\n"
            if (!context.Servers.Any())
            {
                foreach (var server in Servers.Items)
                    context.Servers.Add(server);
                context.SaveChanges();
            }

            if (!context.Senders.Any())
            {
                foreach (var sender in Senders.Items)
                    context.Senders.Add(sender);
                context.SaveChanges();
            }

            if (!context.Mails.Any())
            {
                foreach (var item in Mails.Items)
                    context.Mails.Add(item);
                context.SaveChanges();
            }

            if (!context.Recipients.Any())
            {
                foreach (var recipient in Recipients.Items)
                    context.Recipients.Add(recipient);
                context.SaveChanges();
            }

            if (!context.SchedulerTasks.Any())
            {
                foreach (var schedulerTask in SchedulerTasks.Items)
                    context.SchedulerTasks.Add(schedulerTask);
                context.SaveChanges();
            }
        }
    }
}
