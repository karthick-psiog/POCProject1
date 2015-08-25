namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableCreation3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AuditLogs", "userid", c => c.Int(nullable: false));
            CreateIndex("dbo.AuditLogs", "userid");
            AddForeignKey("dbo.AuditLogs", "userid", "dbo.Users", "userid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditLogs", "userid", "dbo.Users");
            DropIndex("dbo.AuditLogs", new[] { "userid" });
            DropColumn("dbo.AuditLogs", "userid");
        }
    }
}
