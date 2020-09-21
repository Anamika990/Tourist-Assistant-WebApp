namespace TouristGuidAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "GroupName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "GroupName");
        }
    }
}
