namespace Tour_Plan_Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblTour_Detail
    {
        [Key]
        public int TourDetail_ID { get; set; }

        public int Booking_FID { get; set; }
        public int Room_quantity { get; set; }

        public int Room_FID { get; set; }

        public decimal Room_Price { get; set; }

        public virtual tblBookTour tblBookTour { get; set; }

        public virtual tblRoom tblRoom { get; set; }
    }
}
