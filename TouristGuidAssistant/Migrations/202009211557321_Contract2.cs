namespace TouristGuidAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contract2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HireGuides", "TravlerName", c => c.String(nullable: false));
            AlterColumn("dbo.HireGuides", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.HireGuides", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HireGuides", "Address", c => c.String());
            AlterColumn("dbo.HireGuides", "Phone", c => c.String());
            AlterColumn("dbo.HireGuides", "TravlerName", c => c.String());
        }
    }
}
