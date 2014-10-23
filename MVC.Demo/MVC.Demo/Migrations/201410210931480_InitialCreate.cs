namespace MVC.Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PointOfInterests",
                c => new
                    {
                        PointOfInterestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.Geography(),
                    })
                .PrimaryKey(t => t.PointOfInterestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PointOfInterests");
        }
    }
}
