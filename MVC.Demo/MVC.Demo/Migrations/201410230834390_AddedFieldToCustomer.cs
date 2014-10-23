namespace MVC.Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFieldToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "RequiredIntField", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "RequiredIntField");
        }
    }
}
