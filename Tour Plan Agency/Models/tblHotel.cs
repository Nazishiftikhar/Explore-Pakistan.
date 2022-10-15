namespace Tour_Plan_Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblHotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblHotel()
        {
            tblRooms = new HashSet<tblRoom>();
            tblHotelServices = new HashSet<tblHotelService>();
        }

        [Key]
        public int Hotel_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Hotel_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Hotel_Location { get; set; }

        [StringLength(50)]
        public string Hotel_Email { get; set; }

        [StringLength(50)]
        public string Hotel_Phone { get; set; }

        [StringLength(100)]
        public string Hotel_Image { get; set; }

        public int? City_FID { get; set; }

        public virtual tblCity tblCity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRoom> tblRooms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHotelService> tblHotelServices { get; set; }
    }
}
