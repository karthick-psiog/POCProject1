namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemoteCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RemoteCustomer",
                c => new
                    {
                        remoteuserid = c.Int(nullable: false, identity: true),
                        mobile = c.String(nullable: false, maxLength: 15),
                        DOB = c.DateTime(nullable: false),
                        firstname = c.String(nullable: false, maxLength: 25),
                        lastname = c.String(maxLength: 25),
                        address = c.String(nullable: false, maxLength: 1500),
                        city = c.String(nullable: false, maxLength: 50),
                        PIN = c.String(nullable: false, maxLength: 6),
                        state = c.String(nullable: false, maxLength: 50),
                        country = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.remoteuserid)
                .Index(t => t.mobile, unique: true, name: "mobile");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.RemoteCustomer", "mobile");
            DropTable("dbo.RemoteCustomer");
        }
    }
}
