namespace Tour_Plan_Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblHotelService
    {
        [Key]
        public int Service_ID { get; set; }

        [StringLength(50)]
        public string Service_Name { get; set; }

        [StringLength(50)]
        public string Service_Price { get; set; }

        public int? Hotel_FID { get; set; }

        public virtual tblHotel tblHotel { get; set; }
    }
}
