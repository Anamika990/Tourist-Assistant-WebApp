namespace TouristGuidAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users4 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tests",
                c => new
                    {
                        roll = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.roll);
            
        }
    }
}
