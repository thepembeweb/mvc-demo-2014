namespace MVC.Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomerEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 64),
                        LastName = c.String(nullable: false, maxLength: 64),
                        Email = c.String(nullable: false, maxLength: 256),
                        Age = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
