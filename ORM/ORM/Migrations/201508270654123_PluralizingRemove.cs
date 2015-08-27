namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PluralizingRemove : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLog",
                c => new
                    {
                        userid = c.Int(nullable: false),
                        eventtypeid = c.Int(nullable: false),
                        transid = c.Int(nullable: false, identity: true),
                        source = c.String(nullable: false, maxLength: 1000),
                        logmessage = c.String(nullable: false, maxLength: 1000),
                        logtimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.transid)
                .ForeignKey("dbo.EventType", t => t.eventtypeid, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.userid, cascadeDelete: true)
                .Index(t => t.userid)
                .Index(t => t.eventtypeid);
            
            CreateTable(
                "dbo.EventType",
                c => new
                    {
                        eventtypeid = c.Int(nullable: false, identity: true),
                        eventtype = c.String(nullable: false, maxLength: 150),
                        isactive = c.Boolean(),
                    })
                .PrimaryKey(t => t.eventtypeid);
            
            CreateTable(
                "dbo.User",
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
                "dbo.Customer",
                c => new
                    {
                        userid = c.Int(nullable: false),
                        mobile = c.String(nullable: false, maxLength: 15),
                        PIN = c.String(maxLength: 128),
                        DOB = c.DateTime(nullable: false),
                        firstname = c.String(nullable: false, maxLength: 25),
                        lastname = c.String(maxLength: 25),
                        address = c.String(nullable: false, maxLength: 1500),
                        city = c.String(nullable: false, maxLength: 50),
                        state = c.String(nullable: false, maxLength: 50),
                        country = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.userid, t.mobile })
                .ForeignKey("dbo.ServiceArea", t => t.PIN)
                .ForeignKey("dbo.User", t => t.userid, cascadeDelete: true)
                .Index(t => t.userid)
                .Index(t => t.PIN);
            
            CreateTable(
                "dbo.ServiceArea",
                c => new
                    {
                        PIN = c.String(nullable: false, maxLength: 128),
                        isactive = c.Boolean(),
                    })
                .PrimaryKey(t => t.PIN);
            
            CreateTable(
                "dbo.EmailLog",
                c => new
                    {
                        transid = c.Int(nullable: false),
                        emailaddress = c.String(nullable: false, maxLength: 50),
                        emailstatus = c.Int(nullable: false),
                        senttimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.transid)
                .ForeignKey("dbo.AuditLog", t => t.transid)
                .Index(t => t.transid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailLog", "transid", "dbo.AuditLog");
            DropForeignKey("dbo.Customer", "userid", "dbo.User");
            DropForeignKey("dbo.Customer", "PIN", "dbo.ServiceArea");
            DropForeignKey("dbo.AuditLog", "userid", "dbo.User");
            DropForeignKey("dbo.AuditLog", "eventtypeid", "dbo.EventType");
            DropIndex("dbo.EmailLog", new[] { "transid" });
            DropIndex("dbo.Customer", new[] { "PIN" });
            DropIndex("dbo.Customer", new[] { "userid" });
            DropIndex("dbo.AuditLog", new[] { "eventtypeid" });
            DropIndex("dbo.AuditLog", new[] { "userid" });
            DropTable("dbo.EmailLog");
            DropTable("dbo.ServiceArea");
            DropTable("dbo.Customer");
            DropTable("dbo.User");
            DropTable("dbo.EventType");
            DropTable("dbo.AuditLog");
        }
    }
}
