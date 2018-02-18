namespace HotelCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.hotel_Note",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.hotel_Task", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.hotel_Task",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceType = c.String(),
                        Status = c.String(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.hotel_Room", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.hotel_Room",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nr = c.Int(nullable: false),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.hotel_RoomType", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.hotel_Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Room_Id = c.Int(),
                        Type_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.hotel_Room", t => t.Room_Id)
                .ForeignKey("dbo.hotel_RoomType", t => t.Type_Id)
                .ForeignKey("dbo.hotel_User", t => t.User_Id)
                .Index(t => t.Room_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.hotel_RoomType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.hotel_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.hotel_Room", "Type_Id", "dbo.hotel_RoomType");
            DropForeignKey("dbo.hotel_Task", "Room_Id", "dbo.hotel_Room");
            DropForeignKey("dbo.hotel_Reservation", "User_Id", "dbo.hotel_User");
            DropForeignKey("dbo.hotel_Reservation", "Type_Id", "dbo.hotel_RoomType");
            DropForeignKey("dbo.hotel_Reservation", "Room_Id", "dbo.hotel_Room");
            DropForeignKey("dbo.hotel_Note", "Task_Id", "dbo.hotel_Task");
            DropIndex("dbo.hotel_Reservation", new[] { "User_Id" });
            DropIndex("dbo.hotel_Reservation", new[] { "Type_Id" });
            DropIndex("dbo.hotel_Reservation", new[] { "Room_Id" });
            DropIndex("dbo.hotel_Room", new[] { "Type_Id" });
            DropIndex("dbo.hotel_Task", new[] { "Room_Id" });
            DropIndex("dbo.hotel_Note", new[] { "Task_Id" });
            DropTable("dbo.hotel_User");
            DropTable("dbo.hotel_RoomType");
            DropTable("dbo.hotel_Reservation");
            DropTable("dbo.hotel_Room");
            DropTable("dbo.hotel_Task");
            DropTable("dbo.hotel_Note");
        }
    }
}
