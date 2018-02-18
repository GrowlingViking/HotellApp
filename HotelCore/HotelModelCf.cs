namespace HotelCore
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using HotelCore.Entities;

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
            modelBuilder.Entity<Note>()
                .ToTable("Note")
                .HasRequired(n => n.Task)
                .WithMany(t => t.Notes);

            modelBuilder.Entity<Task>()
                .ToTable("Task")
                .HasRequired(t => t.Room)
                .WithMany(r => r.Tasks);

            modelBuilder.Entity<Reservation>()
                .ToTable("Reservation")
                .HasRequired(r => r.Type);

            modelBuilder.Entity<Reservation>()
                .HasRequired(r => r.User)
                .WithMany(u => u.Reservations);

            modelBuilder.Entity<Reservation>()
                .HasRequired(r => r.Type);

            modelBuilder.Entity<Room>()
                .ToTable("Room")
                .HasMany(r => r.Reservations)
                .WithOptional(r => r.Room);

            modelBuilder.Entity<RoomType>().ToTable("RoomType");
        }
    }
}
