namespace HotelCore
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using HotelCore.Entities;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Entity.ModelConfiguration;

    public partial class HotelModelCf : DbContext
    {
        public HotelModelCf()
            : base("name=HotelModelCf")
        {
        }

        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Types().Configure(entity
                => entity.ToTable("hotel_" + entity.ClrType.Name));
        }
    }
}
