namespace TouristGuidAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contract1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contracts", "name");
        }
    }
}
