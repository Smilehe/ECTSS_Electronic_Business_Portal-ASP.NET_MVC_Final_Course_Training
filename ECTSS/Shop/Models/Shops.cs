namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shops")]
    public partial class Shops
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "商品编号")]
        public string Number { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "商品名称")]
        public string Name { get; set; }

        [Display(Name = "进价")]
        public double PurPrice { get; set; }

        [Display(Name = "售价")]
        public double Price { get; set; }

        [Display(Name = "销售数量")]
        public int SalesVolumes { get; set; }

        [Display(Name = "类别I")]
        public int CategoryI { get; set; }

        [Display(Name = "类别II")]
        public int CategoryII { get; set; }

        [Display(Name = "供应商")]
        public int Supplier { get; set; }

        [Required]
        [StringLength(50)]
        public string KeyAttribute { get; set; }
    }
}
