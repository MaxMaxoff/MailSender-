namespace MailSender.lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datarestriction : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mails", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.Mails", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.MailsLists", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Recipients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Recipients", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.SchedulerTasks", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Servers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Servers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Senders", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Senders", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Senders", "Address", c => c.String());
            AlterColumn("dbo.Senders", "Name", c => c.String());
            AlterColumn("dbo.Servers", "Address", c => c.String());
            AlterColumn("dbo.Servers", "Name", c => c.String());
            AlterColumn("dbo.SchedulerTasks", "Name", c => c.String());
            AlterColumn("dbo.Recipients", "Address", c => c.String());
            AlterColumn("dbo.Recipients", "Name", c => c.String());
            AlterColumn("dbo.MailsLists", "Name", c => c.String());
            AlterColumn("dbo.Mails", "Body", c => c.String());
            AlterColumn("dbo.Mails", "Subject", c => c.String());
        }
    }
}
