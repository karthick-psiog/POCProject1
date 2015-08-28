namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemoteCustomerActiveStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RemoteCustomer", "isactive", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RemoteCustomer", "isactive");
        }
    }
}
