namespace TouristGuidAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Registrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        NID = c.String(nullable: false),
                        DateOfBirth = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        UserType = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        confirmPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
