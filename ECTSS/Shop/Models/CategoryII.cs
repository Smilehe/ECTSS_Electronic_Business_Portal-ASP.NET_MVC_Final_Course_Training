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

        [Display(Name = "类别I编号")]
        public int CategorylID { get; set; }

        [Display(Name = "编号")]
        public int Number { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "类别")]
        public string Categoryl { get; set; }
    }
}
