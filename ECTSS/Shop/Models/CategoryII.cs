namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryII")]
    public partial class CategoryII
    {
        public int ID { get; set; }

        [Display(Name = "���I���")]
        public int CategorylID { get; set; }

        [Display(Name = "���")]
        public int Number { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "���")]
        public string Categoryl { get; set; }
    }
}
