namespace Tour_Plan_Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblWebService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WServices_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string WServices_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string WServices_Price { get; set; }

        [StringLength(500)]
        public string WServices_Description { get; set; }
    }
}
