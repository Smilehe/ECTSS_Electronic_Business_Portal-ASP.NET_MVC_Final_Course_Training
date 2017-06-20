namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryI")]
    public partial class CategoryI
    {
        public int ID { get; set; }
        [Display(Name = "���")]
        public int Number { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "���")]
        public string Category { get; set; }
    }
}
