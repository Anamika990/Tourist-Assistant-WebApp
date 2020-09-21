namespace TouristGuidAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HireGuide : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HireGuides", "Day", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HireGuides", "Day", c => c.Int(nullable: false));
        }
    }
}
