namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableCreation2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile" }, "dbo.Customers");
            DropIndex("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile" });
            DropColumn("dbo.AuditLogs", "Customer_userid");
            DropColumn("dbo.AuditLogs", "Customer_mobile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AuditLogs", "Customer_mobile", c => c.String(maxLength: 15));
            AddColumn("dbo.AuditLogs", "Customer_userid", c => c.Int());
            CreateIndex("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile" });
            AddForeignKey("dbo.AuditLogs", new[] { "Customer_userid", "Customer_mobile" }, "dbo.Customers", new[] { "userid", "mobile" });
        }
    }
}
