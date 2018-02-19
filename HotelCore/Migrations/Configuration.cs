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
            if (context.RoomTypes.Count() < 4)
            {
                RoomType rtSingle = new RoomType { Id = 1, Name = "Single" };
                RoomType rtDouble = new RoomType { Id = 2, Name = "Double" };
                RoomType rtFamily = new RoomType { Id = 3, Name = "Family" };
                RoomType rtPenthouse = new RoomType { Id = 4, Name = "Penthouse" };
                context.RoomTypes.AddOrUpdate(rtSingle, rtDouble,
                    rtFamily, rtPenthouse);

                AddRooms(context, 1, 20, rtSingle);
                AddRooms(context, 21, 40, rtDouble);
                AddRooms(context, 41, 60, rtFamily);
                AddRooms(context, 61, 65, rtPenthouse);
            }


            context.Users.AddOrUpdate(new User { Id = 1, UserName = "Erik", Password = "" });
        }

        private void AddRooms(HotelCore.HotelModelCf context, int fromNum, int toNum, RoomType type)
        {
            for (int i = fromNum; i < toNum; ++i)
            {
                context.Rooms.AddOrUpdate(new Room { Id = i, Nr = i, Type = type });
            }
        }
    }
}
