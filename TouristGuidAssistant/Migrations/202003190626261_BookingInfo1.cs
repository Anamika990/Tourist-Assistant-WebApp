namespace TouristGuidAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingInfo1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingInfoes",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        TravelarGroupName = c.String(),
                        DestinationForm = c.String(),
                        DestinationTo = c.String(),
                    })
                .PrimaryKey(t => t.BookingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookingInfoes");
        }
    }
}
