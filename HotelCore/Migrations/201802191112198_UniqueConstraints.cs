namespace HotelCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.hotel_RoomType", "Name", c => c.String(false, 15, true, true));
            CreateIndex("dbo.hotel_RoomType", "Name", true, "RoomTypeNameUniqueIdx");
        }
        
        public override void Down()
        {
            DropIndex("dbo.hotel_RoomType", "RoomTypeNameUniqueIdx");
            AlterColumn("dbo.hotel_RoomType", "Name", c => c.String());
        }
    }
}
