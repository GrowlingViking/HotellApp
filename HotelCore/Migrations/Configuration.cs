namespace HotelCore.Migrations
{
    using HotelCore.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelCore.HotelModelCf>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HotelCore.HotelModelCf";
        }

        protected override void Seed(HotelCore.HotelModelCf context)
        {
            context.RoomTypes.AddOrUpdate(new RoomType { Id = 1, Name = "Single" }, new RoomType { Id = 2, Name = "Double" },
                new RoomType { Id = 3, Name = "Family" }, new RoomType { Id = 4, Name = "Penthouse" });

            context.Users.AddOrUpdate(new User { Id = 1, UserName = "Erik", Password = "" });
        }
    }
}
