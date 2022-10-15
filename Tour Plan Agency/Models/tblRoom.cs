namespace Tour_Plan_Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblRoom")]
    public partial class tblRoom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblRoom()
        {
            tblTour_Detail = new HashSet<tblTour_Detail>();
        }

        [Key]
        public int Room_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Room_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string No_Of_Person { get; set; }

        [StringLength(100)]
        public string Room_image { get; set; }
        [NotMapped]
         public int quantity { get; set; }

        public int? Hotel_FID { get; set; }

        public decimal Room_Price { get; set; }

        public virtual tblHotel tblHotel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTour_Detail> tblTour_Detail { get; set; }
    }
}
