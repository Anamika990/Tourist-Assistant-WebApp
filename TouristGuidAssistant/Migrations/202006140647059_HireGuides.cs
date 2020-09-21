namespace TouristGuidAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HireGuides : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HireGuides",
                c => new
                    {
                        HireID = c.Int(nullable: false, identity: true),
                        DestinationFrom = c.String(nullable: false),
                        DestinationTo = c.String(nullable: false),
                        Day = c.Int(nullable: false),
                        TravlerName = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.HireID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HireGuides");
        }
    }
}
