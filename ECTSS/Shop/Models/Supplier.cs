namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        public int ID { get; set; }

        [Display(Name = "编号")]
        public int Number { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "供应商名称")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "供应商地址")]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "关键字")]
        public string Keyword { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "邮政编码")]
        public string Postcode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "联系电话")]
        public string ContNumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "联系人")]
        public string Contacts { get; set; }

        [Required]
        [Display(Name = "类别I")]
        public int CommodityI { get; set; }

        [Required]
        [Display(Name = "类别II")]
        public int CommodityII { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "银行账号")]
        public string BankAccount { get; set; }
    }
}
