using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Tour_Plan_Agency.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model15")
        {
        }

        public virtual DbSet<tblAdmin> tblAdmins { get; set; }
        public virtual DbSet<tblBookTour> tblBookTours { get; set; }
        public virtual DbSet<tblCity> tblCities { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblFeedback> tblFeedbacks { get; set; }
        public virtual DbSet<tblHotel> tblHotels { get; set; }
        public virtual DbSet<tblHotelService> tblHotelServices { get; set; }
        public virtual DbSet<tblRoom> tblRooms { get; set; }
        public virtual DbSet<tblTour_Detail> tblTour_Detail { get; set; }
        public virtual DbSet<tblWebService> tblWebServices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBookTour>()
                .HasMany(e => e.tblTour_Detail)
                .WithRequired(e => e.tblBookTour)
                .HasForeignKey(e => e.Booking_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCity>()
                .HasMany(e => e.tblHotels)
                .WithOptional(e => e.tblCity)
                .HasForeignKey(e => e.City_FID);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblBookTours)
                .WithRequired(e => e.tblCustomer)
                .HasForeignKey(e => e.Customer_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblFeedbacks)
                .WithRequired(e => e.tblCustomer)
                .HasForeignKey(e => e.Customer_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblHotel>()
                .HasMany(e => e.tblRooms)
                .WithOptional(e => e.tblHotel)
                .HasForeignKey(e => e.Hotel_FID);

            modelBuilder.Entity<tblHotel>()
                .HasMany(e => e.tblHotelServices)
                .WithOptional(e => e.tblHotel)
                .HasForeignKey(e => e.Hotel_FID);

            modelBuilder.Entity<tblRoom>()
                .HasMany(e => e.tblTour_Detail)
                .WithRequired(e => e.tblRoom)
                .HasForeignKey(e => e.Room_FID)
                .WillCascadeOnDelete(false);
        }
    }
}
