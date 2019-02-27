namespace MailSender.lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Body = c.String(),
                        MailsList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MailsLists", t => t.MailsList_Id)
                .Index(t => t.MailsList_Id);
            
            CreateTable(
                "dbo.MailsLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        SendingList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SendingLists", t => t.SendingList_Id)
                .Index(t => t.SendingList_Id);
            
            CreateTable(
                "dbo.SchedulerTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Time = c.DateTime(nullable: false),
                        Mails_Id = c.Int(),
                        MailServer_Id = c.Int(),
                        Recipients_Id = c.Int(),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MailsLists", t => t.Mails_Id)
                .ForeignKey("dbo.Servers", t => t.MailServer_Id)
                .ForeignKey("dbo.SendingLists", t => t.Recipients_Id)
                .ForeignKey("dbo.Senders", t => t.Sender_Id)
                .Index(t => t.Mails_Id)
                .Index(t => t.MailServer_Id)
                .Index(t => t.Recipients_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.Servers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Port = c.Int(nullable: false),
                        UseSSL = c.Boolean(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SendingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Senders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchedulerTasks", "Sender_Id", "dbo.Senders");
            DropForeignKey("dbo.SchedulerTasks", "Recipients_Id", "dbo.SendingLists");
            DropForeignKey("dbo.Recipients", "SendingList_Id", "dbo.SendingLists");
            DropForeignKey("dbo.SchedulerTasks", "MailServer_Id", "dbo.Servers");
            DropForeignKey("dbo.SchedulerTasks", "Mails_Id", "dbo.MailsLists");
            DropForeignKey("dbo.Mails", "MailsList_Id", "dbo.MailsLists");
            DropIndex("dbo.SchedulerTasks", new[] { "Sender_Id" });
            DropIndex("dbo.SchedulerTasks", new[] { "Recipients_Id" });
            DropIndex("dbo.SchedulerTasks", new[] { "MailServer_Id" });
            DropIndex("dbo.SchedulerTasks", new[] { "Mails_Id" });
            DropIndex("dbo.Recipients", new[] { "SendingList_Id" });
            DropIndex("dbo.Mails", new[] { "MailsList_Id" });
            DropTable("dbo.Senders");
            DropTable("dbo.SendingLists");
            DropTable("dbo.Servers");
            DropTable("dbo.SchedulerTasks");
            DropTable("dbo.Recipients");
            DropTable("dbo.MailsLists");
            DropTable("dbo.Mails");
        }
    }
}
