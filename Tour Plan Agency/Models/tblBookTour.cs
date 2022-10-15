namespace Tour_Plan_Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblBookTour")]
    public partial class tblBookTour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblBookTour()
        {
            tblTour_Detail = new HashSet<tblTour_Detail>();
        }

        [Key]
        public int Booking_ID { get; set; }

        public DateTime? Booking_Date { get; set; }

        [StringLength(50)]
        public string Booking_Status { get; set; }
        public string Payment { get; set; }

        [StringLength(50)]
        public string Booking_Type { get; set; }

        public int Customer_FID { get; set; }

        [StringLength(50)]
        public string Availability_status { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTour_Detail> tblTour_Detail { get; set; }
    
    }
}
