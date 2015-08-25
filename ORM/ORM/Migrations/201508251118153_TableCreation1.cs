namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableCreation1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile", "Customer_PIN" }, "dbo.Customers");
            DropForeignKey("dbo.Customers", "PIN", "dbo.ServiceAreas");
            DropForeignKey("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile" }, "dbo.Customers");
            DropIndex("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile", "Customer_PIN" });
            DropIndex("dbo.Customers", new[] { "PIN" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "PIN", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Customers", new[] { "userid", "mobile" });
            CreateIndex("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile" });
            CreateIndex("dbo.Customers", "PIN");
            AddForeignKey("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile" }, "dbo.Customers", new[] { "userid", "mobile" });
            AddForeignKey("dbo.Customers", "PIN", "dbo.ServiceAreas", "PIN");
            DropColumn("dbo.AuditLogs", "Customer_PIN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AuditLogs", "Customer_PIN", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Customers", "PIN", "dbo.ServiceAreas");
            DropForeignKey("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile" }, "dbo.Customers");
            DropIndex("dbo.Customers", new[] { "PIN" });
            DropIndex("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "PIN", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", new[] { "userid", "mobile", "PIN" });
            CreateIndex("dbo.Customers", "PIN");
            CreateIndex("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile", "Customer_PIN" });
            AddForeignKey("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile" }, "dbo.Customers", new[] { "userid", "mobile" });
            AddForeignKey("dbo.Customers", "PIN", "dbo.ServiceAreas", "PIN", cascadeDelete: true);
            AddForeignKey("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile", "Customer_PIN" }, "dbo.Customers", new[] { "userid", "mobile", "PIN" });
        }
    }
}
