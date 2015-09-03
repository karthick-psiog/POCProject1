namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUNIQUEKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "PIN", "dbo.ServiceArea");
            DropIndex("dbo.Customer", new[] { "PIN" });
            DropPrimaryKey("dbo.ServiceArea");
            AddColumn("dbo.ServiceArea", "city", c => c.String(maxLength: 50));
            AddColumn("dbo.ServiceArea", "state", c => c.String(maxLength: 50));
            AddColumn("dbo.ServiceArea", "country", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customer", "PIN", c => c.String(maxLength: 6));
            AlterColumn("dbo.ServiceArea", "PIN", c => c.String(nullable: false, maxLength: 6));
            AddPrimaryKey("dbo.ServiceArea", "PIN");
            CreateIndex("dbo.Customer", "PIN");
            AddForeignKey("dbo.Customer", "PIN", "dbo.ServiceArea", "PIN");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "PIN", "dbo.ServiceArea");
            DropIndex("dbo.Customer", new[] { "PIN" });
            DropPrimaryKey("dbo.ServiceArea");
            AlterColumn("dbo.ServiceArea", "PIN", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Customer", "PIN", c => c.String(maxLength: 128));
            DropColumn("dbo.ServiceArea", "country");
            DropColumn("dbo.ServiceArea", "state");
            DropColumn("dbo.ServiceArea", "city");
            AddPrimaryKey("dbo.ServiceArea", "PIN");
            CreateIndex("dbo.Customer", "PIN");
            AddForeignKey("dbo.Customer", "PIN", "dbo.ServiceArea", "PIN");
        }
    }
}
