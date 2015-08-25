namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLogs",
                c => new
                    {
                        eventtypeid = c.Int(nullable: false),
                        transid = c.Int(nullable: false, identity: true),
                        source = c.String(nullable: false, maxLength: 1000),
                        logmessage = c.String(nullable: false, maxLength: 1000),
                        logtimestamp = c.DateTime(nullable: false),
                        Customer_userid = c.Int(),
                        Customer_mobile = c.String(maxLength: 15),
                        Customer_PIN = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.transid)
                .ForeignKey("dbo.Customers", t => new { t.Customer_userid, t.Customer_mobile, t.Customer_PIN })
                .ForeignKey("dbo.EventTypes", t => t.eventtypeid, cascadeDelete: true)
                .Index(t => t.eventtypeid)
                .Index(t => new { t.Customer_userid, t.Customer_mobile, t.Customer_PIN });
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        userid = c.Int(nullable: false),
                        mobile = c.String(nullable: false, maxLength: 15),
                        PIN = c.String(nullable: false, maxLength: 128),
                        DOB = c.DateTime(nullable: false),
                        firstname = c.String(nullable: false, maxLength: 25),
                        lastname = c.String(maxLength: 25),
                        address = c.String(nullable: false, maxLength: 1500),
                        city = c.String(nullable: false, maxLength: 50),
                        state = c.String(nullable: false, maxLength: 50),
                        country = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.userid, t.mobile, t.PIN })
                .ForeignKey("dbo.ServiceAreas", t => t.PIN, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userid, cascadeDelete: true)
                .Index(t => t.userid)
                .Index(t => t.PIN);
            
            CreateTable(
                "dbo.ServiceAreas",
                c => new
                    {
                        PIN = c.String(nullable: false, maxLength: 128),
                        isactive = c.Boolean(),
                    })
                .PrimaryKey(t => t.PIN);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userid = c.Int(nullable: false, identity: true),
                        encryptedpwd = c.String(nullable: false, maxLength: 100),
                        createddate = c.DateTime(nullable: false),
                        lastmodifieddate = c.DateTime(),
                        lastlogindate = c.DateTime(),
                        isactive = c.Boolean(),
                    })
                .PrimaryKey(t => t.userid);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        eventtypeid = c.Int(nullable: false, identity: true),
                        eventtype = c.String(nullable: false, maxLength: 150),
                        isactive = c.Boolean(),
                    })
                .PrimaryKey(t => t.eventtypeid);
            
            CreateTable(
                "dbo.EmailLogs",
                c => new
                    {
                        transid = c.Int(nullable: false),
                        emailaddress = c.String(nullable: false, maxLength: 50),
                        emailstatus = c.Int(nullable: false),
                        senttimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.transid)
                .ForeignKey("dbo.AuditLogs", t => t.transid)
                .Index(t => t.transid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailLogs", "transid", "dbo.AuditLogs");
            DropForeignKey("dbo.AuditLogs", "eventtypeid", "dbo.EventTypes");
            DropForeignKey("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile", "Customer_PIN" }, "dbo.Customers");
            DropForeignKey("dbo.Customers", "userid", "dbo.Users");
            DropForeignKey("dbo.Customers", "PIN", "dbo.ServiceAreas");
            DropIndex("dbo.EmailLogs", new[] { "transid" });
            DropIndex("dbo.Customers", new[] { "PIN" });
            DropIndex("dbo.Customers", new[] { "userid" });
            DropIndex("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile", "Customer_PIN" });
            DropIndex("dbo.AuditLogs", new[] { "eventtypeid" });
            DropTable("dbo.EmailLogs");
            DropTable("dbo.EventTypes");
            DropTable("dbo.Users");
            DropTable("dbo.ServiceAreas");
            DropTable("dbo.Customers");
            DropTable("dbo.AuditLogs");
        }
    }
}
