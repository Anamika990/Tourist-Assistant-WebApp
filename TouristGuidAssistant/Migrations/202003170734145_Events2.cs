namespace TouristGuidAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Events2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Travelgroup", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Travelgroup");
        }
    }
}
